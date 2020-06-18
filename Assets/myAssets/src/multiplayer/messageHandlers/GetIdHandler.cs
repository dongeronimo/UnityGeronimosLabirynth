using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeWebSocket;
using Newtonsoft.Json;
class GetIdHandler
{
    public bool CanRequest(WebSocket webSocket)
    {
        if (webSocket.State == WebSocketState.Open && IsRequesting == false && GotIdentity == false)
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
        getIdRequestData.Add("date", CurrentDateUtility.GetCurrentDate());
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