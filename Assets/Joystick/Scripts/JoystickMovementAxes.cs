using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovementAxes 
{
    public Vector2 Calculate(Vector2 eventInLocalCoordinates, Rect uiComponentRect)
    {
        var horizontalMovement = eventInLocalCoordinates.x / uiComponentRect.width * 2.0f;
        var verticalMovement = eventInLocalCoordinates.y / uiComponentRect.height * 2.0f;
        var movementAxis = new Vector2(horizontalMovement, verticalMovement);
        movementAxis.Normalize();
        return movementAxis;
    }
}
