using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeWebSocket;
using Newtonsoft.Json;
using System;

class GetWorldHandler
{
    private bool isRequesting = false;
    public bool CanRequest(WebSocket websocket, string WebsocketClientId)
    {
        if (websocket.State == WebSocketState.Open && WebsocketClientId != null && WebsocketClientId.Length > 0 && isRequesting == false)
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
    public List<RemoteGameObject> HandleResponse(Dictionary<string, string> responseDict)
    {
        Debug.Log("Number of items: " + responseDict.Count);
        try
        {
            var remoteGameObjects = JsonConvert.DeserializeObject<List<RemoteGameObject>>(responseDict["gameObjects"]);
            isRequesting = false;
            return remoteGameObjects;
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            isRequesting = false;
            return new List<RemoteGameObject>();
        }
    }
}
