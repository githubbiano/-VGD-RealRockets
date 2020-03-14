using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMode : MonoBehaviour
{
    public GameObject cha;
    public GameObject ball;

    private bool once;
    private Quaternion resetRotation;
    // Start is called before the first frame update
    void Start()
    {
        resetRotation = transform.localRotation;
        once = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (cha.GetComponent<CharacterControls>().isLocked())
        {
            once = true;
            //this makes the camera chase the ball, this script is in the focus object that has the camera as child so they move together
            //so that both the player and the ball are always on screen when the camera is locked on the ball.
            transform.LookAt(ball.transform);
        }
        else
        {
            if (once)
            {
                transform.localRotation = resetRotation;
                once = false;
            }
        }
    }
}
