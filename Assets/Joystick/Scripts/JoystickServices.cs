using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickService : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowTouchPosition(Vector2 positionInScreenCoordinates)
    {
        GetComponentInChildren<ShowOrHideTouchPosition>().ShowTouchPosition();
        GetComponentInChildren<ChangeTouchIndicatorPosition>().SetPosition(positionInScreenCoordinates);
    }
    public void HideTouchPosition()
    {
        GetComponentInChildren<ShowOrHideTouchPosition>().HideTouchPosition();
    }
}
