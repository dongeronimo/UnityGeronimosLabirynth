using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButtonClick : MonoBehaviour
{
    public JoystickServices joystickServices;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (joystickServices.IsNotJumping)
            {
                joystickServices.BeginJump();
            }
            
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
