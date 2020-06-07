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
        if (characterController.isGrounded == false)
        {
            //Changes the position
            lastFallVector = Vector3.Slerp(lastFallVector, Vector3.down, 0.1f);
            characterController.SimpleMove(lastFallVector);
            //Changes the animation
            animator.SetLayerWeight(animator.GetLayerIndex("Fall"), 0.5f);
        }
        else
        {
            lastFallVector = transform.forward;
            animator.SetLayerWeight(animator.GetLayerIndex("Fall"), 0.0f);
        }
    }
}
