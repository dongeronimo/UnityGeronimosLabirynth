using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,
    IDragHandler, IEndDragHandler
{
    private bool isPressed ;
    private Vector2 currentEventPosition;
    public void OnDrag(PointerEventData eventData)
    {
        isPressed = true;
        currentEventPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isPressed = false;
        currentEventPosition = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        isPressed = true;
        currentEventPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        currentEventPosition = eventData.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("isPressed = " + isPressed);
        if(isPressed == true)
        {
            GetComponent<JoystickServices>().ShowTouchPosition(currentEventPosition);
        }
        else
        {
            GetComponent<JoystickServices>().HideTouchPosition();
        }
    }
}
