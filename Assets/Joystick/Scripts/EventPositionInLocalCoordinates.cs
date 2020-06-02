using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***
 * All EventSystem events positions are in Screen Coordinates. This class calculates
 * the event position in a local system whose origin is rectTransformPositionInScreenCoordinates.
 * From it's name can be deduced that the main use will be to calculate the event position relative
 * to a RectTransform.
*/
public class EventPositionInLocalCoordinates 
{
    public Vector2 Calculate(Vector2 rectTransformPositionInScreenCoordinates, Vector2 eventInScreenCoordinates)
    {
        Vector2 eventLocalCoordinates = eventInScreenCoordinates - rectTransformPositionInScreenCoordinates;

        return eventLocalCoordinates;
    }
}
