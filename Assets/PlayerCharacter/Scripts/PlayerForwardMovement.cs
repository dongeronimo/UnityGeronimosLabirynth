using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForwardMovement : MonoBehaviour
{
    public JoystickController joystickController;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystickController.isPressed)
        {
            var characterController = GetComponent<CharacterController>();
            characterController.SimpleMove(transform.forward);
            animator.SetFloat("ForwardSpeed", transform.forward.magnitude);
            //transform.position = transform.position + transform.forward * Time.deltaTime;
        }
        else
        {
            animator.SetFloat("ForwardSpeed", 0.0f);
        }
        
    }
}
