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
    private float rocketSpeed;
    private CharacterController cc;
    private float gravity;
    private float actualSpeed;
    private float curForQt;
    private float curSidQt;
    private float airForQt;
    private float airSidQt;
    private float vSpeed;
    private float vHovSpeed;
    private float jumpSpeed;
    private bool hoover;
    private bool fly;
    private bool lockable;
    private float fuel;
    private float currFuel;
    private float deplRat;
    private float refRate;
    private Vector3 jumpForDir;
    private Vector3 jumpSidDir;

    // Start is called before the first frame update
    void Start()
    {
        //get manager component
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        charManager = GameObject.FindGameObjectWithTag("CharController").GetComponent<CharacterManager>();
        speed =charManager.getSpeed();
        rocketSpeed = charManager.getRocketSpeed();
        lock_ball = false;
        cc = gameObject.GetComponent<CharacterController>();
        gravity = manager.getGravity();
        vSpeed = 0;
        jumpSpeed = charManager.getJumpSpeed();
        hoover = false;
        fly = false;
        fuel = charManager.getMaxFuel();
        currFuel = fuel;
        deplRat = charManager.getDepletionRate();
        refRate = charManager.getRefillRate();
        airForQt = 0;
        airSidQt = 0;
        jumpForDir = Vector3.zero;
        jumpSidDir = Vector3.zero;
        lockable = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection;
        //if key is pressed toggle lock mode
        if (Input.GetKeyDown(KeyCode.Tab) && lockable)
        {
            lock_ball = !lock_ball;
        }

        //get forward and side motion
        curForQt = Input.GetAxis("Vertical");
        curSidQt = Input.GetAxis("Horizontal");

        if (cc.isGrounded)
        {
            airForQt = curForQt;
            airSidQt = curSidQt;
            if (currFuel < fuel)
            {
                currFuel += refRate * Time.deltaTime;
            }
        }
        else if(!hoover)
        {
            curForQt = airForQt;
            curSidQt = airSidQt;
        }

        Vector3 forward = Vector3.zero;
        Vector3 side = Vector3.zero;
        if (fly)
        {
            lockable = false;
            lock_ball = false;
            forward = cam.transform.TransformDirection(Vector3.forward);
            curSidQt = 0;
            curForQt = rocketSpeed;
            if (currFuel > 0)
            {
                currFuel -= (deplRat) * Time.deltaTime;
            }
        }
        else
        {
            lockable = true;
            if (hoover)
            {
                airForQt = 0;
                airSidQt = 0;
                jumpSidDir = Vector3.zero;
                jumpForDir = Vector3.zero;
                if (currFuel > 0)
                {
                    currFuel -= (deplRat / 2) * Time.deltaTime;
                }

                if (gameObject.transform.position.y < 2f && curForQt < 0f)
                {
                    curForQt = 0;
                }
                //if hoovering go up/down
                vHovSpeed = curForQt * speed;
                //side direction is relative to character now
                side = transform.TransformDirection(Vector3.right).normalized;//direzione laterale
            }
            else
            {//if not hoovering and grounded
                if (cc.isGrounded)
                {
                    vHovSpeed = 0;
                    //get camera forward vector and transform it in world direction
                    forward = cam.transform.TransformDirection(Vector3.forward);//direzione frontale
                                                                                //set forward y to 0 so that movement is 2d only (since camera can look up or down, we only want forward and side)
                    forward.y = 0;
                    jumpForDir = forward;
                    //same as above but side axis is consistent, we don't need to adjust it to 2d
                    side = cam.transform.TransformDirection(Vector3.right);//direzione laterale
                    jumpSidDir = side;
                }
                else
                {
                    //get camera forward vector and transform it in world direction
                    forward = jumpForDir;
                    //same as above but side axis is consistent, we don't need to adjust it to 2d
                    side = jumpSidDir;
                }

            }
        }
        
        actualSpeed = curSidQt + curForQt;//used on animator
        //next move direction
        moveDirection = side * curSidQt + forward * curForQt;
        //apply speed
        moveDirection *= speed;
        //Cancel vertical speed if on ground
        if (cc.isGrounded || currFuel <= 0)
        {
            if (hoover)
            {
                hoover = false;
            }
            else if (fly)
            {
                fly = false;
                
            }
        }
        //if we are grounded we can jump
        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
        {
            vSpeed = jumpSpeed;
        }

        //if we are not grounded
        if (!cc.isGrounded)
        {
            if (!hoover && !fly)
            {
                //apply gravity
                vSpeed -= gravity * Time.deltaTime;
            }
            else 
            {
                vSpeed = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space) && !hoover && !fly)
            {
                hoover = true;
                vSpeed = 0;
                Vector3 fwd = cam.transform.forward;
                fwd.y = 0;
                transform.rotation = Quaternion.LookRotation(fwd);
            }
            if ((Input.GetKeyUp(KeyCode.Space) && hoover) ||  currFuel<=0)
            {
                hoover = false;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                fly = true;
                hoover = false;
            }
        }
        //clamp vector to avoid extra diagonal speed
        moveDirection = Vector3.ClampMagnitude(moveDirection, speed);
        if (!fly)
        {
            //apply vertical movement
            moveDirection.y = vSpeed + vHovSpeed;
        }
        

        //apply movement
        cc.Move(moveDirection * Time.deltaTime);
    }

    private void LateUpdate()
    {
        bool moving= (Input.GetAxis("Vertical")+Input.GetAxis("Horizontal")) != 0;
        if ((cc.isGrounded && moving) || fly)
        {
            //rotate gameobject towards movement direction
            //this is in LateUpdate to avoid camera jittering
            //get camera forward vector and transform it in world direction
            Vector3 forward = cam.transform.TransformDirection(Vector3.forward).normalized;//direzione frontale
            if (cc.isGrounded || currFuel<=0)
            {
                //set forward y to 0 so that rotation is 2d only (since camera can look up or down, we only want forward and side)
                forward.y = 0;
                transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
            }
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
    public bool isFlying()
    {
        return this.fly;
    }
}
