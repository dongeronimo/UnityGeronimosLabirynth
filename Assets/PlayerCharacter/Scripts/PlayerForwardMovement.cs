﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForwardMovement : MonoBehaviour
{
    public JoystickController joystickController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joystickController.isPressed)
        {
            var characterController = GetComponent<CharacterController>();
            characterController.SimpleMove(transform.forward);
            //transform.position = transform.position + transform.forward * Time.deltaTime;
        }
        
    }
}
