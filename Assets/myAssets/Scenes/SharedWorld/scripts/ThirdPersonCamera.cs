using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform PlayerCamera;
    public Transform Target;
    void Start()
    {
        
    }

    void Update()
    {
        PlayerCamera.position = transform.position;
        PlayerCamera.LookAt(Target);
    }
}
