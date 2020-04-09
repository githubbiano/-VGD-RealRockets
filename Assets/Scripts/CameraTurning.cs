using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurning : MonoBehaviour
{
    public CharacterControls chara;
    public GameObject ball;
    public GameObject focus;
    public Transform EXACT;
    public GameObject test;

    private Vector3 RESET_POSITION;
    private Vector3 RESET_OFFSET;
    private float speed;
    private Vector3 offset;
    private GameObject target;
    private LayerMask ClipMask;
    
    private bool flag_target_changed;
    private bool flag_once;

    // Start is called before the first frame update
    void Start()
    {
        target = focus;
        RESET_POSITION = transform.localPosition;
        offset = EXACT.position - focus.transform.position;
        RESET_OFFSET = offset;
        speed = 70.0f;
        flag_target_changed = false;
        flag_once = false;
        ClipMask = 0 << LayerMask.NameToLayer("Clip") | 1 <<LayerMask.NameToLayer("NoClip");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (!chara.isLocked())
        {
            if (chara.isHoovering() && !flag_once)
            {
                flag_once = true;
                offset = EXACT.position - focus.transform.position;
                transform.position = EXACT.position;
            }

            if(!chara.isHoovering())
            {
                flag_once = false;
            }

            if (flag_target_changed)//avoids multiple executions
            {
                //change target to look at
                target = focus;
                //reset camera position when unlocking
                offset = EXACT.position - focus.transform.position;
                transform.position = EXACT.position;
                flag_target_changed = false;
            }
            //Split rotation in 2 quaternions to better manage y axis transition
            Quaternion turnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speed * Time.deltaTime, Vector3.up);
            Quaternion turnAngleY = Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * speed * Time.deltaTime, transform.right);
            //calculate next camera position 
            Vector3 newOffset = (turnAngleY * turnAngleX) * offset;
            //check if new position is between (arbitrary) boundaries
            if (newOffset.y < -0.8f || newOffset.y > 1.7f)
            {
                //update if necessary
                newOffset = turnAngleX * offset;
            }
            offset = newOffset;
            //check if the camera is clipping and update new position 
            transform.position = cameraReposition(offset); //focus.transform.position + offset; <-- doesn't handle clipping
        }
        else
        {
            if (!flag_target_changed)//avoids multiple executions
            {
                //change target to look at
                target = ball;
                //reset camera position when unlocking
                offset = EXACT.position - focus.transform.position;
                transform.position = EXACT.position;
                flag_target_changed = true;
            }
            transform.position=cameraReposition();
            //    unused code, i found a more efficient implementation here: https://answers.unity.com/questions/1140386/replicating-rocket-league-ball-cam.html
            //    //Rotate camera towards ball and make sure to position it as far away as possible while also keeping the same distance from the focus object
            //    //Current distance
            //    float distance = Vector3.Distance(transform.position, ball.transform.position);
            //    offset = rotateCamera(distance, Vector3.up) * rotateCamera(distance, transform.right) * offset;
            //    Vector3 newPosition= cameraReposition(offset);
            //    RaycastHit hit;
            //    int layerMask = 1 << 8; //check collision only on layer 8
            //    Debug.DrawLine(newPosition, ball.transform.position, Color.red, 20.0f);
            //    if (Physics.Linecast(newPosition, ball.transform.position, out hit, layerMask))
            //    {
            //        if (!hit.collider.gameObject.CompareTag("Raycast"))
            //        {

            //            transform.position = newPosition;
            //        }
            //    }
        }
        transform.LookAt(target.transform.position);
    }

    //reposition camera to avoid clipping
    private Vector3 cameraReposition(Vector3 off) 
    {
        //Camera Reposition On Obstruction (partial) // Source: https://www.youtube.com/watch?v=s2lUw08ZE_Q
        //get offset
        Vector3 unobstructed = off;
        //calculate initialize ideal position
        Vector3 idealPosition = focus.transform.position + unobstructed;

        RaycastHit hit;
        //Debug.Log(Physics.Linecast(focus.transform.position, idealPosition, out hit));
        //linecast from character (camera focus) to camera position (before any adjustment)
        if (Physics.Linecast(focus.transform.position, idealPosition, out hit, ClipMask.value))
        {
            unobstructed = hit.point - focus.transform.position;

            ////if there is something between camera and character
            //if (!hit.collider.gameObject.CompareTag("Player"))
            //{
            //    //put camera on impact point
            //    unobstructed = hit.point - focus.transform.position;

            //}
        }
        //return new camera position
        return focus.transform.position + unobstructed;

    }

    private Vector3 cameraReposition()
    {
        //same as above but another object that keeps the unadjusted position is needed (EXACT) because it very hard to predict camera's next 
        //Camera Reposition On Obstruction (partial) // Source: https://www.youtube.com/watch?v=s2lUw08ZE_Q
        Vector3 unobstructed = EXACT.position - focus.transform.position;
        Vector3 idealPosition = focus.transform.position + unobstructed;

        RaycastHit hit;
        if (Physics.Linecast(focus.transform.position, idealPosition, out hit, ClipMask.value))
        {
            unobstructed = hit.point - focus.transform.position;
            //if (hit.collider.gameObject.CompareTag("NoClip"))
            //{
            //    unobstructed = hit.point - focus.transform.position;
                
            //}
        }
        //return new camera position
        return focus.transform.position + unobstructed;

    }

    //unused function, i found a more efficient implementation here: https://answers.unity.com/questions/1140386/replicating-rocket-league-ball-cam.html
    private Quaternion rotateCamera(float distance, Vector3 axis)
    {
        //Calculate next position in both directions to check which one gets the camere further away
        Quaternion turnAngleXR = Quaternion.AngleAxis(1 * speed * 2 * Time.deltaTime, axis);
        Vector3 newOffsetR = turnAngleXR * offset;
        Vector3 nextPositionR = cameraReposition(newOffsetR);
        //next distance if rotating in main direction
        float nextDistanceR = Vector3.Distance(nextPositionR, ball.transform.position);
        //repeat for opposite direction
        Quaternion turnAngleXL = Quaternion.AngleAxis((-1) * speed * 2 * Time.deltaTime, axis);
        //Quaternion turnAngleYD = Quaternion.AngleAxis(0 * speed * 2 * Time.deltaTime, transform.right);
        Vector3 newOffsetL = turnAngleXL * offset;
        Vector3 nextPositionL = cameraReposition(newOffsetL);
        float nextDistanceL = Vector3.Distance(nextPositionL, ball.transform.position);
        /////////////////////////
        //use distances to decide where to move the camera
        if (nextDistanceL > distance && nextDistanceL > nextDistanceR)
        {
            return turnAngleXL;
            //offset = newOffsetL;
            //return nextPositionL;
        }
        else if (nextDistanceR > distance && nextDistanceR > nextDistanceL)
        {
            return turnAngleXR;
            //offset = newOffsetR;
            //return nextPositionR;
        }
        else
        {
            return Quaternion.AngleAxis(0, axis);
            //return focus.transform.position+offset;
        }
    }
}
