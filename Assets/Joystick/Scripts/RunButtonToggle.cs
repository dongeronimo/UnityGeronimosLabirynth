using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RunButtonToggle : MonoBehaviour, IPointerClickHandler
{
    public Sprite RunningIcon;
    public Sprite WalkingIcon;
    public JoystickServices joystickService;
    public bool IsRunning;
    public void OnPointerClick(PointerEventData eventData)
    {
        IsRunning = !IsRunning;
        joystickService.SetRunning(IsRunning);
        SetCurrentIcon();
    }
    private void SetCurrentIcon()
    {
        if (IsRunning)
        {
            GetComponent<Image>().sprite = RunningIcon;
        }
        else
        {
            GetComponent<Image>().sprite = WalkingIcon;
        }
    }

    void Start()
    {
        SetCurrentIcon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
