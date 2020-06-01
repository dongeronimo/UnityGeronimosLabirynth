using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Behaviour))]
public class ShowOrHideTouchPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTouchPosition()
    {
        GetComponent<Behaviour>().enabled = true;
    }
    public void HideTouchPosition()
    {
        GetComponent<Behaviour>().enabled = false;
    }
}
