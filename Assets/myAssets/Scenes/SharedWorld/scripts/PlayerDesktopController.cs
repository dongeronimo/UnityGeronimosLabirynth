using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDesktopController : MonoBehaviour
{
    public Vector3 currentOrientation;
    private CharacterController characterController;
    void Start()
    {

        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        SetCurrentOrientationUsingKeyboarInput();
        CommitMovementChanges();
    }
    void SetCurrentOrientationUsingKeyboarInput()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");
        
    }
    void CommitMovementChanges()
    {
        transform.LookAt(transform.position + currentOrientation);

    }
}
