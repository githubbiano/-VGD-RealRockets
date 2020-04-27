using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    float smooth = 1.0f;
    float startTime;
    float endTime;
    float i = 0.0f;
    // Update is called once per frame
    void Start()
    {
        startTime = Time.time;
        endTime = 10f;
    }

    void Update()
    {
        //t = t + 0.0000000000001f;
        Quaternion target = Quaternion.Euler(20, 45 + i, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        //Vector3 pos = new Vector3(-7.044f, 3.242f, -3.604f + i);
        //transform.position = Vector3.Slerp(transform.position, pos, Time.deltaTime * smooth);
        transform.position = transform.position + new Vector3(0, 0, 0.005f);
        i += 0.05f;
        
    }
}
