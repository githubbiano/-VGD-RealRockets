using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private float jumpSpeed;
    private float speed;
    private float shotStrength;
    private float maxFuel;
    private float depletionRate;

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

    public float getShotStrength()
    {
        return this.shotStrength;
    }
    public void setShotStrength(float strength)
    {
        this.shotStrength = strength;
    }

    public float getMaxFuel()
    {
        return this.maxFuel; ;
    }
    public void setMaxFuel(float fuel)
    {
        this.maxFuel = fuel;
    }

    public float getDepletionRate()
    {
        return this.depletionRate;
    }
    public void setDepletionRate(float rate)
    {
        this.depletionRate = rate;
    }
}
