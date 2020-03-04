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
    void Update()
    {
        //Vector3 look = new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z);
        transform.LookAt(target.transform.position);
    }
}
