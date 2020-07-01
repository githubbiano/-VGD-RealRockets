using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private float jumpSpeed;
    private float speed;
    private float rocketSpeed;
    private float landShotStrength;
    private float airShotStrength;
    private float maxFuel;
    private float depletionRate;
    private float refillRate;

    // Start is called before the first frame update
    void Start()
    {
        jumpSpeed = 30.0f;
        speed = 10.0f;
        maxFuel = 100;
        depletionRate = 20;
        refillRate = 8;
        landShotStrength = 1000;
        airShotStrength = 30;
        rocketSpeed = speed * 2;
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

    public float getLandShotStrength()
    {
        return this.landShotStrength;
    }
    public void setLandShotStrength(float strength)
    {
        this.landShotStrength = strength;
    }

    public float getAirShotStrength()
    {
        return this.airShotStrength;
    }
    public void setAirShotStrength(float strength)
    {
        this.airShotStrength = strength;
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

    public float getRefillRate()
    {
        return this.refillRate;
    }
    public void setRefillRate(float rate)
    {
        this.refillRate = rate;
    }

    public float getRocketSpeed()
    {
        return this.rocketSpeed;
    }
    public void setRocketSpeed(float speed)
    {
        rocketSpeed = speed;
    }
}










/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private float jumpSpeed;
    private float speed;
    private float rocketSpeed;
    private float landShotStrength;
    private float airShotStrength;
    private float maxFuel;
    private float depletionRate;
    private float refillRate;

    // Start is called before the first frame update
    void Start()
    {
        jumpSpeed = 30.0f;
        speed = 10.0f;
        maxFuel = 100;
        depletionRate = 5;
        refillRate = 3;
        landShotStrength = 1000;
        airShotStrength = 3000;
        rocketSpeed = speed * 2;
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

    public float getLandShotStrength()
    {
        return this.landShotStrength;
    }
    public void setLandShotStrength(float strength)
    {
        this.landShotStrength = strength;
    }

    public float getAirShotStrength()
    {
        return this.airShotStrength;
    }
    public void setAirShotStrength(float strength)
    {
        this.airShotStrength = strength;
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

    public float getRefillRate()
    {
        return this.refillRate;
    }
    public void setRefillRate(float rate)
    {
        this.refillRate = rate;
    }

    public float getRocketSpeed()
    {
        return this.rocketSpeed;
    }
    public void setRocketSpeed(float speed)
    {
        rocketSpeed = speed;
    }
}

*/
