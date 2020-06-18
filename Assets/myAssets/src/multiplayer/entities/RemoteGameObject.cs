using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

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
