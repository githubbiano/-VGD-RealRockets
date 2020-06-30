using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCollision : MonoBehaviour
{
    public CharacterControls cc;
    private bool doneFlag;
    private CharacterManager charman;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
        doneFlag = false;
        charman = GameObject.FindGameObjectWithTag("CharController").GetComponent<CharacterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.grounded())
        {
            doneFlag = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Collisione");
        if (collision.gameObject.CompareTag("ball") && cc.isFlying() && !doneFlag)
        {
            Debug.Log("SphereColliderHit");

            doneFlag = true;
            anim.SetTrigger("tiroAlVolo");
            cc.landing();
            Vector3 dir = collision.GetContact(0).point - transform.position;
            dir = -dir.normalized;
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(dir * charman.getAirShotStrength(), ForceMode.Impulse);
        }
    }
}
