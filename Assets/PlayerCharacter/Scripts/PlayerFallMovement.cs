using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 lastFallVector;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded == false)
        {
            lastFallVector = Vector3.Slerp(lastFallVector, Vector3.down, 0.1f);
            characterController.SimpleMove(lastFallVector);
        }
        else
        {
            lastFallVector = transform.forward;
        }
    }
}
