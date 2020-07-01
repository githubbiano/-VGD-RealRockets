using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickNpc : MonoBehaviour
{
    //Hitbox Status
    private bool isHitboxActive;
    private CharacterManager charman;
    public GameObject ob;
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
            rb.AddForce((ob.transform.forward *charman.getLandShotStrength()) + ob.transform.up * 1000, ForceMode.Acceleration);
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
