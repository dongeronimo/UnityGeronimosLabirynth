﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardinalOrientation : MonoBehaviour
{
    public float XAxis;
    public float YAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var currentPosition = transform.position;
        var positionToLookAt = currentPosition + new Vector3(XAxis*2, 0 , YAxis*2);
        transform.LookAt(positionToLookAt);
    }
}