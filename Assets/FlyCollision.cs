using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCollision : MonoBehaviour
{
    public CharacterControls cc;
    private bool doneFlag;
    // Start is called before the first frame update
    void Start()
    {
        doneFlag = false;
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
        if (collision.gameObject.CompareTag("ball") && cc.isFlying() && !doneFlag)
        {
            Debug.Log("SphereColliderHit");

            doneFlag = true;
            cc.landing();
            Vector3 dir = collision.GetContact(0).point - transform.position;
            Debug.DrawLine(gameObject.transform.position, collision.gameObject.transform.position, Color.red, 20.0f);
            dir = -dir.normalized;
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(dir * 30, ForceMode.Impulse);
        }
    }
}
