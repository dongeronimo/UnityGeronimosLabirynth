using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickServices : MonoBehaviour
{
    public Vector2 CurrentMovementAxes = new Vector2();
    public bool CharacterIsRunning;
    private EventPositionInLocalCoordinates localPositionCalculator = new EventPositionInLocalCoordinates();
    private JoystickMovementAxes movementAxesCalculator = new JoystickMovementAxes();
    public bool IsNotJumping = true;
    internal void BeginJump()
    {
        IsNotJumping = false;
    }

    internal void SetRunning(bool isRunning)
    {
        CharacterIsRunning = isRunning;
    }

    public void ShowTouchPosition(Vector2 positionInScreenCoordinates)
    {
        GetComponentInChildren<ShowOrHideTouchPosition>().ShowTouchPosition();
        GetComponentInChildren<ChangeTouchIndicatorPosition>().SetPosition(positionInScreenCoordinates);
        var p = GetComponent<RectTransform>().position;
        Vector2 localPosition = localPositionCalculator.Calculate(p, positionInScreenCoordinates);
        CurrentMovementAxes = movementAxesCalculator.Calculate(localPosition, GetComponent<RectTransform>().rect);
    }
    public void HideTouchPosition()
    {
        GetComponentInChildren<ShowOrHideTouchPosition>().HideTouchPosition();
    }
}
