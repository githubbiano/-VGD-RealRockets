using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    //Hitbox Status
    private bool isHitboxActive;
    public GameObject cc;
    private CharacterManager charman;
    // Start is called before the first frame update
    void Start()
    {
        isHitboxActive = false;
        charman = GameObject.FindGameObjectWithTag("CharController").GetComponent<CharacterManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball") && isHitboxActive)
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(cc.transform.forward*charman.getLandShotStrength() + cc.transform.up*800, ForceMode.Acceleration);
        }
    }
    public void ActivateHitbox()
    {
        isHitboxActive = true;
    }
    public void DeactivateHitbox()
    {
        isHitboxActive = false;
    }
}