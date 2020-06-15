using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using UnityEngine;
using Newtonsoft.Json;

public class NetworkManager : MonoBehaviour
{
    public string ServerUrl;
    public string WebsocketClientId;
    private WebSocket websocket;
    public bool isAlive = false;
    public bool isConnected = false;
    private GetIdHandler getIdHandler = new GetIdHandler();
    // Start is called before the first frame update
    void Start()
    {
        websocket = new WebSocket(ServerUrl);
        websocket.OnMessage += (sender, e) =>
        {
            Dictionary<string, string> responseDict = ResponseDataToDict(e.Data);
            ValidateHasTypeElseThrowError(responseDict);
            getIdHandler.HandleGetIdResponse(responseDict);
            if (getIdHandler.GotIdentity == true)
            {
                WebsocketClientId = getIdHandler.WebsocketClientId;
            } 
        };
        websocket.Connect();
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

    
    // Update is called once per frame
    void Update()
    {
        isAlive = websocket.IsAlive;
        isConnected = websocket.IsConnected;
        getIdHandler.RequestIdentity(websocket);
    }
}

class GetIdHandler
{
    public static readonly string GET_ID = "getId";
    public bool IsRequesting = false;
    public bool GotIdentity = false;
    public string WebsocketClientId = "";

    public void RequestIdentity(WebSocket socket)
    {
        if(!IsRequesting && !GotIdentity)
        {
            socket.Send(GET_ID);
            IsRequesting = true;
        }
    }
    public void HandleGetIdResponse(Dictionary<string, string> responseDict)
    {
        if (responseDict["type"] == "getId")
        {
            WebsocketClientId = responseDict["id"];
            GotIdentity = true;
            IsRequesting = false;
        }
    }
}