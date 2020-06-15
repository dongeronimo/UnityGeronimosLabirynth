using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using WebSocketSharp;
using foo;

public class ConnectionToServer : MonoBehaviour
{
    //private WebSocket ws;
    //private Foobar foo = new Foobar();
    // Start is called before the first frame update
    void Start()
    {
        //ws = new WebSocket("ws://localhost:8080/helloSockets");
        //ws.OnMessage+= (sender, e) =>
        //{
        //    Debug.Log(e.Data);
        //};
        //ws.Connect();
        //ws.Send("hello");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        //ws.Close();
    }

}
