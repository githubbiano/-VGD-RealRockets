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
    private float curForQt;
    private float curSidQt;
    private float vSpeed;
    private float vHovSpeed;
    private float jumpSpeed;
    public bool hoover;

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
        hoover = false;
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
        curForQt = Input.GetAxis("Vertical");
        curSidQt = Input.GetAxis("Horizontal");

        Vector3 forward = Vector3.zero;
        Vector3 side = Vector3.zero;
        if (hoover)
        {
            if (gameObject.transform.position.y < 2f && curForQt < 0f)
            {
                Debug.Log("HERE");
                curForQt = 0;
            }
            //if hoovering go up/down
            vHovSpeed = curForQt * speed;
            //side direction is relative to character now
            side = transform.TransformDirection(Vector3.right).normalized;//direzione laterale
        }
        else
        {//if not hoovering and grounded
            if (cc.isGrounded) {
                //get camera forward vector and transform it in world direction
                forward = cam.transform.TransformDirection(Vector3.forward).normalized;//direzione frontale
                //set forward y to 0 so that movement is 2d only (since camera can look up or down, we only want forward and side)
                forward.y = 0;
                //same as above but side axis is consistent, we don't need to adjust it to 2d
                side = cam.transform.TransformDirection(Vector3.right).normalized;//direzione laterale
            }
        }
        actualSpeed = curSidQt + curForQt;//used on animator
        //next move direction
        moveDirection =side * curSidQt + forward * curForQt;
        //apply speed
        moveDirection *= speed;

        //Cancel vertical speed if on ground
        if (cc.isGrounded)
        {
            vSpeed = -1.0f;
            hoover = false;
        }
        //if we are grounded we can jump
        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
        {
            vSpeed = jumpSpeed;
        }
        //if we are not grounded we apply gravity
        if (!cc.isGrounded)
        {
            if (!hoover)
            {
                //apply gravity
                vSpeed -= gravity * Time.deltaTime;
            }
            else 
            {
                vSpeed = 0; 
            }

            if (Input.GetKeyDown(KeyCode.Space) && !hoover)
            {
                hoover = true;
                vSpeed = 0;
                Vector3 fwd = cam.transform.forward;
                fwd.y = 0;
                transform.rotation = Quaternion.LookRotation(fwd);
            }
            if (Input.GetKeyUp(KeyCode.Space) && hoover)
            {
                hoover = false;
            }
        }
        //apply vertical movement
        moveDirection.y = vSpeed+vHovSpeed;

        //apply movement
        cc.Move(moveDirection * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (!hoover && cc.isGrounded)
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
            Vector3 newDir = Vector3.RotateTowards(transform.forward, side * curSidQt + forward * curForQt, 10.0f, 0.0f);
            //apply rotation
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }

    public bool isLocked()
    {
        return this.lock_ball;
    }
    public float getActualSpeed()
    {
        return actualSpeed;
    }
    public bool isHoovering()
    {
        return this.hoover;
    }
}
