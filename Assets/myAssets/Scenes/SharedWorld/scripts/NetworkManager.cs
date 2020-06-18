using System.Collections;
using System.Collections.Generic;
using NativeWebSocket;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Globalization;

public class NetworkManager : MonoBehaviour
{
    public GameObject remoteObjectPrefab;
    public string ServerUrl;
    public string WebsocketClientId;
    private WebSocket websocket;
    public bool isAlive = false;
    public bool isConnected = false;
    private GetIdHandler getIdHandler = new GetIdHandler();
    private GetWorldHandler getWorldHandler = new GetWorldHandler();
    private Dictionary<string, RemoteGameObject> remoteObjectsDict = new Dictionary<string, RemoteGameObject>();
    private Dictionary<string, GameObject> remoteGameObjects = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    async void Start()
    {
        websocket = new WebSocket(ServerUrl);
        websocket.OnMessage += Websocket_OnMessage;
        await websocket.Connect();
    }

    private void Websocket_OnMessage(byte[] data)
    {
        Dictionary<string, string> responseDict = new ResponseDataToDictUtility().ResponseDataToDict(data);
        new HasTypeValidator().Validate(responseDict);
        getIdHandler.HandleResponse(responseDict);
        //TODO: Refatorar isso aqui.
        if (responseDict["type"] == "worldRequest")
        {
            //Pega o mundo no servidor
            List<RemoteGameObject> remoteObjects = getWorldHandler.HandleResponse(responseDict);
            //Guarda na lista de objetos remotos.
            foreach(RemoteGameObject o in remoteObjects)
            {
                if(remoteObjectsDict.ContainsKey(o.id) == true)
                {
                    remoteObjectsDict[o.id] = o;
                }
                else
                {
                    remoteObjectsDict.Add(o.id, o);
                }
            }
            //TODO: para cada objeto remoto atualizar o gameobject local, criar se não existir ou deletar se ele não existir mais no servidor
            foreach (string k in remoteObjectsDict.Keys.ToList())
            {
                if (remoteGameObjects.ContainsKey(k))
                {
                    //TODO: Se o game object vindo do servidor existe na lista atual, atualiza.
                    remoteGameObjects[k].transform.position = new Vector3(remoteObjectsDict[k].positionX, remoteObjectsDict[k].positionY, remoteObjectsDict[k].positionZ);
                }
                else
                {
                    //TODO: Se não existe, cria.
                    GameObject go = Instantiate(remoteObjectPrefab, new Vector3(remoteObjectsDict[k].positionX, remoteObjectsDict[k].positionY, remoteObjectsDict[k].positionZ), Quaternion.identity);
                    remoteGameObjects.Add(k, go);
                }
            }
            foreach(string k in remoteGameObjects.Keys.ToList())
            {
                if (!remoteObjectsDict.ContainsKey(k))
                {
                    //TODO: Se só existe no mundo local mas nao existe no servidor, deleta localmente.
                    Destroy(remoteGameObjects[k]);
                    remoteGameObjects.Remove(k);
                }
            }

        }
        if (getIdHandler.GotIdentity == true)
        {
            WebsocketClientId = getIdHandler.WebsocketClientId;
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






