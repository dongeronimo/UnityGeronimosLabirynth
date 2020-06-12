using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform PlayerCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCamera.position = transform.position;
        PlayerCamera.LookAt(GetComponentInParent<Transform>().position);
    }
}
