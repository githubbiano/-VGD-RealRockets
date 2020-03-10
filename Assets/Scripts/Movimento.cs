using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;

    //hashing delle stringhe in numeri -> confronti molto piu rapidi

    //codifichiamo il nome dello stato a cui passare quando si 
    //preme il tasto di salto (j)
    int hash_trigger_deveSaltare = Animator.StringToHash("deveSaltare");
    int hash_trigger_deveTirare = Animator.StringToHash("deveTirare");
    int hash_trigger_tiroAlVolo = Animator.StringToHash("tiroAlVolo");
    int hash_trigger_tempCrash = Animator.StringToHash("tempCrash");


    int nameStatoCorrente = Animator.StringToHash("Base Layer.Armature|Fly");
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        float movimento = Input.GetAxis("Vertical");
        anim.SetFloat("velocita", movimento);

        AnimatorStateInfo statoCorrente = anim.GetCurrentAnimatorStateInfo(0);

        if (statoCorrente.nameHash == nameStatoCorrente)
        {
            if (Input.GetKeyDown(KeyCode.J))
                anim.SetTrigger(hash_trigger_tempCrash);
            if (Input.GetKeyDown(KeyCode.Space))
                anim.SetTrigger(hash_trigger_tiroAlVolo);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.J))
                anim.SetTrigger(hash_trigger_deveSaltare);
            if (Input.GetKeyDown(KeyCode.Space))
                anim.SetTrigger(hash_trigger_deveTirare);
        }
       


    }
}
