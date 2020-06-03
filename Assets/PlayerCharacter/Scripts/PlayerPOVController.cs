using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPOVController : MonoBehaviour
{
    public Transform SceneCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SceneCamera.position = this.transform.position;
        SceneCamera.LookAt(transform.parent.position);
    }
}
