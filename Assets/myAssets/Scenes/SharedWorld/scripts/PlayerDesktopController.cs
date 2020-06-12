using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDesktopController : MonoBehaviour
{

    private CharacterController characterController;
    void Start()
    {
  
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        SetCurrentOrientationUsingKeyboarInput();
        MoveForwardOrBackwardUsingKeyboardInput();
    }

    private void MoveForwardOrBackwardUsingKeyboardInput()
    {
        float verticalAxis = Input.GetAxisRaw("Vertical");
        characterController.Move(transform.forward * verticalAxis * 3 * Time.deltaTime);
    }

    void SetCurrentOrientationUsingKeyboarInput()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.up, 30 * horizontalAxis * Time.deltaTime);
    }


}
