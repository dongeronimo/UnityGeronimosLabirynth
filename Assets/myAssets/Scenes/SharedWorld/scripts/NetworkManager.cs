using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public string ServerUrl;
    private WebSocket websocket;
    // Start is called before the first frame update
    void Start()
    {
        websocket = new WebSocket(ServerUrl);
        websocket.OnMessage += (sender, e) =>
        {
            Debug.Log(e.Data);
        };
        websocket.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
