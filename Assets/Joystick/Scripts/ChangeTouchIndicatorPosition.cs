using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTouchIndicatorPosition : MonoBehaviour
{
    public void SetPosition(Vector2 posInLocalCoord)
    {
        GetComponent<RectTransform>().position = posInLocalCoord;
    }
}
