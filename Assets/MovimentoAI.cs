using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimentoAI : MonoBehaviour
{

    private Animator anim;
    private float runAnimSpeedMult;

    private NavMeshAgent navMeshAgent;
    //public CharacterController cc;

    public GameObject Ball;
    public float speed = 0.1f;

    public float attackDistance = 1.0f;

    public float followDistance = 3.0f;

    public float flyDistance = 150.0f;

    public float AttackProbability = 0.5f;

    public ParticleSystem fire;
    public ParticleSystem emission;

    int hash_trigger_deveSaltare = Animator.StringToHash("deveSaltare");
    int hash_trigger_deveTirare = Animator.StringToHash("deveTirare");
    int hash_trigger_tiroAlVolo = Animator.StringToHash("tiroAlVolo");
    int hash_trigger_tempCrash = Animator.StringToHash("tempCrash");
    int hash_trigger_terra = Animator.StringToHash("terra");


    int animationFly = Animator.StringToHash("Base Layer.Armature|Fly");
    int animationAir = Animator.StringToHash("Base Layer.StopAir");
    // Start is called before the first frame update
    void Start()
    {
        runAnimSpeedMult = 1.8f;//run animation speed
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        anim.SetFloat("runMul", runAnimSpeedMult);


    }

    // Update is called once per frame
    void Update()
    {

        AnimatorStateInfo statoCorrente = anim.GetCurrentAnimatorStateInfo(0);
        if (navMeshAgent.enabled)
        {
            Vector3 ballT = Ball.transform.position;
            ballT.y = 0;
            float dist = Vector3.Distance(ballT, this.transform.position);
            //bool shoot = false;
            bool shoot = (dist <= attackDistance);
            bool follow = (dist < followDistance);
            bool fly = (dist < flyDistance && dist > followDistance);

            /*if (fly)
            {
                //navMeshAgent.SetDestination(Ball.transform.position);
                if (statoCorrente.fullPathHash == Animator.StringToHash("Base Layer.Armature|Idle"))
                    anim.SetTrigger("deveSaltare");
                if (statoCorrente.fullPathHash == Animator.StringToHash("Base Layer.Armature|Jump"))
                    anim.SetFloat("velocita", speed);
                if (statoCorrente.fullPathHash == Animator.StringToHash("Base Layer.Armature|Fly"))
                    navMeshAgent.SetDestination(Ball.transform.position);
            }*/

            if (follow)
            {
                
                //anim.SetTrigger("npcTerra");
                //if (statoCorrente.fullPathHash == Animator.StringToHash("Base Layer.Armature|Idle"))
                anim.SetFloat("velocita", speed);
                if (statoCorrente.fullPathHash == Animator.StringToHash("Base Layer.Armature|Run"))
                    navMeshAgent.SetDestination(Ball.transform.position);
            }

            
            else anim.SetFloat("velocita", 0.0f);

            if (shoot)
            {
                anim.SetTrigger(hash_trigger_deveTirare);
            }
        }

        /*
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
        */


    }

   
        
    }
