using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    private Vector3 lastFallVector;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        animator.SetFloat("FallSpeed", lastFallVector.y);
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
