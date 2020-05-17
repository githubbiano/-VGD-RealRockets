﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movimento : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private float runAnimSpeedMult;
    public CharacterController cc;
    public float speed = 0.1f;

    public ParticleSystem fire;
    public ParticleSystem emission;
    //hashing delle stringhe in numeri -> confronti molto piu rapidi

    //codifichiamo il nome dello stato a cui passare quando si 
    //preme il tasto di salto (j)
    int hash_trigger_deveSaltare = Animator.StringToHash("deveSaltare");
    int hash_trigger_deveTirare = Animator.StringToHash("deveTirare");
    int hash_trigger_tiroAlVolo = Animator.StringToHash("tiroAlVolo");
    int hash_trigger_tempCrash = Animator.StringToHash("tempCrash");
    int hash_trigger_terra = Animator.StringToHash("terra");


    int animationFly = Animator.StringToHash("Base Layer.Armature|Fly");
    int animationAir = Animator.StringToHash("Base Layer.StopAir");
    void Start()
    {
        Debug.Log(speed);
        runAnimSpeedMult = 1.8f;//run animation speed
        anim = GetComponent<Animator>();
        anim.SetFloat("runMul", runAnimSpeedMult);//set run animation speed
        //cc = GetComponent<CharacterController>();

       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //float movimento = Input.GetAxis("Vertical");
        //anim.SetFloat("velocita", movimento);
        Move();
        AnimatorStateInfo statoCorrente = anim.GetCurrentAnimatorStateInfo(0);
        //anim.SetFloat("velocità", cc.getActualSpeed());
        if (statoCorrente.fullPathHash == animationFly || statoCorrente.fullPathHash == animationAir)
        {
            //fire.Emit(1);
            //emission.Emit(1);
            var fr = fire.emission;
            var em = emission.emission;
            em.enabled = true;
            fr.enabled = true;
            if (Input.GetKeyDown(KeyCode.J))
                anim.SetTrigger(hash_trigger_tempCrash); 
            if (Input.GetKeyDown(KeyCode.Space))
                anim.SetTrigger(hash_trigger_tiroAlVolo);

            if (cc.isGrounded && statoCorrente.fullPathHash == animationAir)
            {
                em.enabled = false;
                fr.enabled = false;
                anim.SetTrigger(hash_trigger_terra);
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
                anim.SetTrigger(hash_trigger_deveSaltare);
            if (Input.GetKeyDown(KeyCode.Mouse0))
                anim.SetTrigger(hash_trigger_deveTirare);
        }
       
        


    }

    private void Move()
    {
        if (cc.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                //gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
                anim.SetFloat("velocita", speed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //gameObject.transform.Translate(Vector3.down * speed * Time.deltaTime);
                anim.SetFloat("velocita", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
                anim.SetFloat("velocita", speed);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                //gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
                anim.SetFloat("velocita", speed);
            }
            else
            {
                anim.SetFloat("velocita", 0.0f);
            }
        }
        /*if (Input.GetKey(KeyCode.W)) {
            gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
            anim.SetFloat("velocita", speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.down * speed * Time.deltaTime);
            anim.SetFloat("velocita", speed);
        }
        else if (Input.GetKey(KeyCode.D))  {
            gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
            anim.SetFloat("velocita", speed);
        }
        else if (Input.GetKey(KeyCode.S)) {
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
            anim.SetFloat("velocita", speed);
        }
        else
        {
            anim.SetFloat("velocita", 0.0f);
        }

        float horizz = Input.GetAxis("Horizzontal");
        if (horizz != 0.0f)
        {
            Debug.Log("Cambio: " + horizz);
            Vector3 direzione = new Vector3(horizz, 0.0f, 0.0f);
            gameObject.transform.Translate(direzione * speed * Time.deltaTime);
            anim.SetFloat("velocita", horizz);
        }*/
    }
}
