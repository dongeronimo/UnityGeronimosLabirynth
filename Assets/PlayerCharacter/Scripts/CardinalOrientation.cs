using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardinalOrientation : MonoBehaviour
{
    public Vector3 currentOrientation = new Vector3(0,0,1);
    public Vector3 finalOrientation;

    public JoystickServices joystickServices;

    void Start()
    {

    }


    void Update()
    {
        SetXAndYUsingJoystickServices();
        Vector3 interpolatedPosition = Vector3.Slerp(currentOrientation, finalOrientation, 0.1f);
        //Debug.Log("current = " + currentOrientation + ", intermediate = " + interpolatedPosition + ", final = " + finalOrientation);
        currentOrientation = interpolatedPosition;
        ChangeOrientationBasedOnXAndY();
    }
    private void SetXAndYUsingJoystickServices()
    {
        if(joystickServices)
        {
            var x = joystickServices.CurrentMovementAxes.x;
            var z = joystickServices.CurrentMovementAxes.y;
            finalOrientation = new Vector3(x, 0, z);
        } 
    }
    private void ChangeOrientationBasedOnXAndY()
    {
        var currentPosition = transform.position;
        var positionToLookAt = currentPosition + currentOrientation;
        transform.LookAt(positionToLookAt);
    }
}
