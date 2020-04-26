using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera2 : MonoBehaviour
{
    float smooth = 1.0f;
    float i = 0.0f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Quaternion target = Quaternion.Euler(20, 235 + i, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        transform.position = transform.position - new Vector3(0, 0, 0.005f);
        i += 0.05f;
    }
}
