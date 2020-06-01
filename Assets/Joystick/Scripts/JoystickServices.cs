using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickService : MonoBehaviour
{
    public Vector2 CurrentMovementAxes = new Vector2();
    private EventPositionInLocalCoordinates localPositionCalculator = new EventPositionInLocalCoordinates();
    private JoystickMovementAxes movementAxesCalculator = new JoystickMovementAxes();
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

        Rect joystickRect = GetComponent<RectTransform>().rect;
        Vector2 joystickScreenPosition = joystickRect.position;
        Vector2 localPosition = localPositionCalculator.Calculate(joystickScreenPosition, positionInScreenCoordinates);
        CurrentMovementAxes = movementAxesCalculator.Calculate(localPosition, joystickRect);

    }
    public void HideTouchPosition()
    {
        GetComponentInChildren<ShowOrHideTouchPosition>().HideTouchPosition();
    }
}
