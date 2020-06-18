using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasTypeValidator
{
    public void Validate(Dictionary<string, string> responseDict)
    {
        if (responseDict.ContainsKey("type") == false)
        {
            throw new System.Exception("Invalid response format: no 'type' in json");
        }
    }
}
