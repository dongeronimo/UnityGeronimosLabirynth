using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardinalOrientation : MonoBehaviour
{
    public Vector3 currentOrientation = new Vector3(0,0,1);
    public Vector3 finalOrientation;
   // public float speed = 1;
   // public float startTime;
    public JoystickServices joystickServices;
    // Start is called before the first frame update
    void Start()
    {
    //    startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        SetXAndYUsingJoystickServices();
        float angleBetweenCurrentAndFinalOrientations = Vector3.Angle(currentOrientation, finalOrientation);
        Debug.Log("angle = " + angleBetweenCurrentAndFinalOrientations);
        //Debug.Log("Angle between vectors = " + angleBetweenCurrentAndFinalOrientations);
        //Vector3.Lerp()
    //    ChangeOrientationBasedOnXAndY();
        //Debug.Log("CurrentOrientation = " + currentOrientation);
        //Debug.Log("FinalOrientation = " + finalOrientation);
    }
    private void SetXAndYUsingJoystickServices()
    {
        if(joystickServices)
        {
            var x = joystickServices.CurrentMovementAxes.x;
            var z = joystickServices.CurrentMovementAxes.y;
            //Debug.Log("x,y = " + x+","+z);
            finalOrientation = new Vector3(x, 0, z);
        } 
    }
    private void ChangeOrientationBasedOnXAndY()
    {
        //var currentPosition = transform.position;
        //var positionToLookAt = currentPosition + currentOrientation;
        //transform.LookAt(positionToLookAt);
               
    }
}
