using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForwardMovement : MonoBehaviour
{
    public float RunSpeedMultiplier;
    public float WalkSpeedMultiplier;
    public JoystickController joystickController;
    private Animator animator;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystickController.isPressed)
        {
            var speedMultiplier = joystickController.GetJoystickService().CharacterIsRunning ? RunSpeedMultiplier : WalkSpeedMultiplier;
            var forwardMultipliedBySpeed = transform.forward * speedMultiplier;
            characterController.SimpleMove(forwardMultipliedBySpeed);
            animator.SetFloat("ForwardSpeed", forwardMultipliedBySpeed.magnitude);
        }
        else
        {
            animator.SetFloat("ForwardSpeed", 0.0f);
        }
    }
}
