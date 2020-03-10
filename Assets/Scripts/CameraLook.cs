using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //make camera look at "target"... target will be set somewhere else and can only be camerafocus or ball
        transform.LookAt(target.transform.position);
    }
}
