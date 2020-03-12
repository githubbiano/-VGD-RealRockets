using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    public GameObject ball;
    public GameObject cam;
    
    private GameManager manager;
    private bool lock_ball;
    private float speed;
    private CharacterController cc;
    private float GRAVITY;
    private float actualSpeed;
    private float curForSpeed;
    private float curSidSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //get manager component
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        speed =manager.getSpeed();
        lock_ball = false;
        cc = gameObject.GetComponent<CharacterController>();
        GRAVITY = manager.getGravity();
    }

    // Update is called once per frame
    void Update()
    {
        //if key is pressed toggle lock mode
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            lock_ball = !lock_ball;
        }
        //get forward and side motion
        curForSpeed = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        curSidSpeed = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 moveDirection;
        //get camera forward vector and transform it in world direction
        Vector3 forward = cam.transform.TransformDirection(Vector3.forward).normalized;//direzione frontale
        //set forward y to 0 so that movement is 2d only (since camera can look up or down, we only want forward and side)
        forward.y = 0;
        //same as above but side axis is consistent, we don't need to adjust it to 2d
        Vector3 side = cam.transform.TransformDirection(Vector3.right).normalized;//direzione laterale
        actualSpeed = curSidSpeed + curForSpeed;//used on animator
        //interpolate movemente to make it smoother
        moveDirection =Vector3.Lerp(transform.position, side * curSidSpeed + forward * curForSpeed, 1f);
        //apply gravity
        moveDirection.y -= GRAVITY * Time.deltaTime;
        //apply movement
        cc.Move(moveDirection);
        
    }
    private void LateUpdate()
    {
        //rotate towards movement direction
        //this is in LateUpdate to avoid camera jittering
        //get camera forward vector and transform it in world direction
        Vector3 forward = cam.transform.TransformDirection(Vector3.forward).normalized;//direzione frontale
        //set forward y to 0 so that movement is 2d only (since camera can look up or down, we only want forward and side)
        forward.y = 0;
        //same as above but side axis is consistent, we don't need to adjust it to 2d
        Vector3 side = cam.transform.TransformDirection(Vector3.right).normalized;//direzione laterale
        //rotate towards movement direction
        Vector3 newDir = Vector3.RotateTowards(transform.forward, side * curSidSpeed + forward * curForSpeed, 10.0f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }


    public bool isLocked()
    {
        return this.lock_ball;
    }
    public float getActualSpeed()
    {
        return actualSpeed;
    }
}
