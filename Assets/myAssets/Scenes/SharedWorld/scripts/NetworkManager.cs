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
        string jsonString = System.Text.Encoding.Default.GetString(data);
        Dictionary<string, string> responseDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
        ValidateHasTypeElseThrowError(responseDict);
        getIdHandler.HandleResponse(responseDict);
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
    public List<RemoteGameObject> HandleResponse(Dictionary<string, string> responseDict)
    {
        Debug.Log("Number of items: " + responseDict.Count);
        try
        {
            var remoteGameObjects = JsonConvert.DeserializeObject<List<RemoteGameObject>>(responseDict["gameObjects"]);
            isRequesting = false;
            return remoteGameObjects;
        }
        catch(Exception e)
        {
            Debug.LogError(e.Message);
            isRequesting = false;
            return new List<RemoteGameObject>();
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

public class RemoteGameObject
{
    [JsonProperty("id")]
    public string id { get; set; }
    [JsonProperty("positionX")]
    public float positionX { get; set; }
    [JsonProperty("positionY")]
    public float positionY { get; set; }
    [JsonProperty("positionZ")]
    public float positionZ { get; set; }

}