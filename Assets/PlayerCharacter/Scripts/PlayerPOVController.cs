using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPOVController : MonoBehaviour
{
    public float YOffset;
    public Transform SceneCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SceneCamera.position = this.transform.position;
        Vector3 target = transform.parent.position + new Vector3(0, YOffset, 0);
        SceneCamera.LookAt(target);
    }
}
