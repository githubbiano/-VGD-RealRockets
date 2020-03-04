using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurning : MonoBehaviour
{
    public GameObject focus;
    private float speed;
    private Vector3 offset;

    public Vector3 text;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - focus.transform.position;
        speed = 50.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Split rotation in 2 quaternions to better manage y axis transition
        Quaternion turnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X")* speed * Time.deltaTime, Vector3.up);
        Quaternion turnAngleY = Quaternion.AngleAxis(-Input.GetAxis("Mouse Y")* speed * Time.deltaTime, transform.right);
        //calculate next camera position 
        Vector3 newOffset = (turnAngleY * turnAngleX) * offset;
        text = newOffset;
        //check if new position is between (arbitrary) boundaries
        if (newOffset.y < -0.8f || newOffset.y > 2.0f)
        {
            //update if necessary
            newOffset= turnAngleX * offset;
        }
        offset = newOffset;
        //check if the camera is clipping and update new position 
        transform.position = cameraReposition(offset); //focus.transform.position + offset; <-- doesn't handle clipping
    }

    //reposition camera to avoid clipping
    private Vector3 cameraReposition(Vector3 offset) 
    {
        //Camera Reposition On Obstruction (partial) // Source: https://www.youtube.com/watch?v=s2lUw08ZE_Q
        Vector3 unobstructed = offset;
        Vector3 idealPosition = focus.transform.position + offset;

        RaycastHit hit;
        if (Physics.Linecast(focus.transform.position, idealPosition, out hit))
        {
            if (!hit.collider.gameObject.CompareTag("Player"))
            {
                //reduce offset if there is an obstruction between camera and player
                unobstructed = hit.point - focus.transform.position;
            }
        }
        //return new camera position
        return focus.transform.position + unobstructed;

    }

}
