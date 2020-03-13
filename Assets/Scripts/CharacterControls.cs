using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    public GameObject ball;
    public GameObject cam;
    
    private GameManager manager;
    private CharacterManager charManager;
    private bool lock_ball;
    private float speed;
    private CharacterController cc;
    private float gravity;
    private float actualSpeed;
    private float curForSpeed;
    private float curSidSpeed;
    private float vSpeed;
    private float jumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //get manager component
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        charManager = GameObject.FindGameObjectWithTag("CharController").GetComponent<CharacterManager>();
        speed =charManager.getSpeed();
        lock_ball = false;
        cc = gameObject.GetComponent<CharacterController>();
        gravity = manager.getGravity();
        vSpeed = 0;
        jumpSpeed = charManager.getJumpSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection;
        //if key is pressed toggle lock mode
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            lock_ball = !lock_ball;
        }

        //get forward and side motion
        curForSpeed = Input.GetAxis("Vertical");
        curSidSpeed = Input.GetAxis("Horizontal");
        //get camera forward vector and transform it in world direction
        Vector3 forward = cam.transform.TransformDirection(Vector3.forward).normalized;//direzione frontale
        //set forward y to 0 so that movement is 2d only (since camera can look up or down, we only want forward and side)
        forward.y = 0;
        //same as above but side axis is consistent, we don't need to adjust it to 2d
        Vector3 side = cam.transform.TransformDirection(Vector3.right).normalized;//direzione laterale
        actualSpeed = curSidSpeed + curForSpeed;//used on animator
        //interpolate movemente to make it smoother
        moveDirection =side * curSidSpeed + forward * curForSpeed;
        //apply speed
        moveDirection *= speed;
        //Cancel vertical speed on ground
        if (cc.isGrounded)
        {
            vSpeed = -1.0f;
        }
        //if we are grounded we can jump
        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
        {
            vSpeed = jumpSpeed;
        }
        //if we are not grounded we apply gravity
        if (!cc.isGrounded)
        {
            //apply gravity
            vSpeed -= gravity * Time.deltaTime;
        }
        //apply vertical movement
        moveDirection.y = vSpeed;

        //apply movement
        cc.Move(moveDirection * Time.deltaTime);

    }

    private void LateUpdate()
    {
        //rotate gameobject towards movement direction
        //this is in LateUpdate to avoid camera jittering
        //get camera forward vector and transform it in world direction
        Vector3 forward = cam.transform.TransformDirection(Vector3.forward).normalized;//direzione frontale
        //set forward y to 0 so that rotation is 2d only (since camera can look up or down, we only want forward and side)
        forward.y = 0;
        //same as above but side axis is consistent, we don't need to adjust it to 2d
        Vector3 side = cam.transform.TransformDirection(Vector3.right).normalized;//direzione laterale
        //rotate towards movement direction
        Vector3 newDir = Vector3.RotateTowards(transform.forward, side * curSidSpeed + forward * curForSpeed, 10.0f, 0.0f);
        //apply rotation
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
