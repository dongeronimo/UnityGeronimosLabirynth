using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using UnityEngine;
using Newtonsoft.Json;

public class NetworkManager : MonoBehaviour
{
    public string ServerUrl;
    private WebSocket websocket;
    private bool GotIdentity = false;
    // Start is called before the first frame update
    void Start()
    {
        websocket = new WebSocket(ServerUrl);
        websocket.OnMessage += (sender, e) =>
        {
            Dictionary<string, string> responseDict = ResponseDataToDict(e.Data);
            ValidateHasTypeElseThrowError(responseDict);
            
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
        if(GotIdentity == false)
        {
            websocket.Send("getId");
        }
    }
}
