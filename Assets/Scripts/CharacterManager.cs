using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private float jumpSpeed;
    private float speed;
    private float shotStrength;
    // Start is called before the first frame update
    void Start()
    {
        jumpSpeed = 30.0f;
        speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float getSpeed()
    {
        return this.speed;
    }
    public void setSpeed(float s)
    {
        this.speed = s;
    }
    public float getJumpSpeed()
    {
        return this.jumpSpeed;
    }
    public void setJumpSpeed(float s)
    {
        this.jumpSpeed = s;
    }
}
