using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    //Hitbox Status
    private bool isHitboxActive;
    public GameObject cc;
    // Start is called before the first frame update
    void Start()
    {
        isHitboxActive = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball")&& isHitboxActive)
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(cc.transform.forward*2000 + cc.transform.up*1000, ForceMode.Acceleration);
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