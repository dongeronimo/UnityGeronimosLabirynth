using System.Collections;
using System.Collections.Generic;
using NativeWebSocket;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.Globalization;

public class NetworkManager : MonoBehaviour
{
    public string ServerUrl;
    public string WebsocketClientId;
    private WebSocket websocket;
    public bool isAlive = false;
    public bool isConnected = false;
    private GetIdHandler getIdHandler = new GetIdHandler();
    private GetWorldHandler getWorldHandler = new GetWorldHandler();
    // Start is called before the first frame update
    async void Start()
    {
        websocket = new WebSocket(ServerUrl);
        websocket.OnMessage += Websocket_OnMessage;
        await websocket.Connect();
    }

    private void Websocket_OnMessage(byte[] data)
    {
        string jsonString = System.Text.Encoding.Default.GetString(data);
        Dictionary<string, string> responseDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
        ValidateHasTypeElseThrowError(responseDict);
        getIdHandler.HandleResponse(responseDict);
        getWorldHandler.HandleResponse(responseDict);
        if (getIdHandler.GotIdentity == true)
        {
            WebsocketClientId = getIdHandler.WebsocketClientId;
        }
    }

    private Dictionary<string, string> ResponseDataToDict(string responseData)
    {
        Dictionary<string, string> responseDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseData);
        return responseDict;
    }

    private void ValidateHasTypeElseThrowError(Dictionary<string, string> responseDict)
    {
        if (responseDict.ContainsKey("type") == false)
        {
            throw new System.Exception("Invalid response format: no 'type' in json");
        }
    }

    private void Update()
    {
        isConnected = websocket.State == WebSocketState.Open;
        if(getWorldHandler.CanRequest(websocket, WebsocketClientId))
        {
            getWorldHandler.DoRequest(websocket, WebsocketClientId);
        }
        if (getIdHandler.CanRequest(websocket))
        {
            getIdHandler.DoRequest(websocket);
        }
    }
}

class GetWorldHandler
{
    private bool isRequesting = false;
    public bool CanRequest(WebSocket websocket, string WebsocketClientId)
    {
        if(websocket.State == WebSocketState.Open && WebsocketClientId != null && WebsocketClientId.Length > 0 && isRequesting == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public async void DoRequest(WebSocket websocket, string WebsocketClientId)
    {
        isRequesting = true;
        Dictionary<string, string> currentStatusRequestData = new Dictionary<string, string>();
        currentStatusRequestData.Add("type", "worldRequest");
        currentStatusRequestData.Add("client", WebsocketClientId);
        currentStatusRequestData.Add("date", CurrentDateUtility.GetCurrentDate());
        await websocket.SendText(JsonConvert.SerializeObject(currentStatusRequestData));
    }
    public void HandleResponse(Dictionary<string, string> responseDict)
    {
        if (responseDict["type"] == "worldRequest")
        {
            //TODO: Lida com o retorno do mundo
            isRequesting = false;
        }
    }
}

class GetIdHandler
{
    public bool CanRequest(WebSocket webSocket)
    {
        if(webSocket.State == WebSocketState.Open && IsRequesting == false && GotIdentity == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public async void DoRequest(WebSocket websocket)
    {
        Dictionary<string, string> getIdRequestData = new Dictionary<string, string>();
        getIdRequestData.Add("type", "idRequest");
        getIdRequestData.Add("date", CurrentDateUtility.GetCurrentDate() );
        IsRequesting = true;
        await websocket.SendText(JsonConvert.SerializeObject(getIdRequestData));
    }

    public static readonly string GET_ID = "getId";
    public bool IsRequesting = false;
    public bool GotIdentity = false;
    public string WebsocketClientId = "";

    
    public void HandleResponse(Dictionary<string, string> responseDict)
    {
        if (responseDict["type"] == "getId")
        {
            WebsocketClientId = responseDict["id"];
            GotIdentity = true;
            IsRequesting = false;
        }
    }
}

class CurrentDateUtility
{
    public static string GetCurrentDate()
    {
        return DateTime.UtcNow.ToString(CultureInfo.CreateSpecificCulture("en-US"));
    }
}