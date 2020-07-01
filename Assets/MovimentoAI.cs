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


    public GameObject compagno;

    public GameObject porta;

    public GameObject Ball;
    //public float speed = 0.1f;

    public float attackDistance = 1.0f;

    public float followDistance = 100f;

    public float flyDistance = 200f;

    public float AttackProbability = 0.5f;

    private float agentSpeed;
    private Vector3 lastPosition;
    private bool canShot;

    bool jump;

    public ParticleSystem fire;
    public ParticleSystem emission;

    int hash_trigger_deveSaltare = Animator.StringToHash("deveSaltare");
    int hash_trigger_deveTirare = Animator.StringToHash("deveTirare");
    int hash_trigger_tiroAlVolo = Animator.StringToHash("tiroAlVolo");
    int hash_trigger_volare = Animator.StringToHash("volare");
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
        jump = false;
        agentSpeed = 0;
        lastPosition = Vector3.zero;
        canShot = true;
    }

    // Update is called once per frame
    void Update()
    {
        agentSpeed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
        AnimatorStateInfo statoCorrente = anim.GetCurrentAnimatorStateInfo(0);
        if (navMeshAgent.enabled)
        {
            float angle = Vector3.Angle(transform.forward, porta.transform.position);
            if (Mathf.Abs(angle) < 135)
            {
                canShot = true;
            }
            else
            {
                canShot = false;
            }
                
            Vector3 ballT = Ball.transform.position;
            ballT.y = 0;
            float distCompagnoBall = Vector3.Distance(ballT, compagno.transform.position);
            float distanzaCompagno = Vector3.Distance(this.transform.position, compagno.transform.position);
            float dist = Vector3.Distance(ballT, this.transform.position);
            //bool shoot = false;
            bool shoot = (dist <= attackDistance);
            bool follow = (dist < 100f);
            bool fly = (dist < flyDistance);

            anim.SetFloat("velocita", agentSpeed);

            if (!follow /*&& !fly*/)
            {
                anim.SetFloat("velocita", 0.0f);
            }

           
            /*else if (fly && !follow)
            {
                
                if (!jump)
                {
                    
                    anim.SetTrigger(hash_trigger_deveSaltare);
                    jump = true;
                }
                else
                {
                    if (statoCorrente.fullPathHash == Animator.StringToHash("Base Layer.Armature|Jump"))
                    {
                        print("vola");
                        anim.SetTrigger(hash_trigger_volare);
                        navMeshAgent.SetDestination(Ball.transform.position);
                        anim.SetFloat("velocita", navMeshAgent.speed);
                    }
                }
            }*/


            else
            {
                //jump = false;
                //anim.SetTrigger(hash_trigger_terra);
                //if (statoCorrente.fullPathHash == Animator.StringToHash("Base Layer.Armature|Run"))
                //{
                if (dist < distCompagnoBall)
                {
                    navMeshAgent.speed = 6.0f;
                    if (canShot)
                        navMeshAgent.stoppingDistance = 0.8f;
                    else
                        navMeshAgent.stoppingDistance = 0f;
                    navMeshAgent.SetDestination(Ball.transform.position);
                    
                }
                else
                {
                    if (distanzaCompagno > 16.0f)
                    {
                        navMeshAgent.speed = 3.0f;
                        navMeshAgent.stoppingDistance = 8.0f;
                        navMeshAgent.SetDestination(compagno.transform.position);
                    }
                    else navMeshAgent.speed = 1.0f;

                }
                //}
            }
        //}


            /*else
            {
                print(Vector3.Distance(ballT, this.transform.position));
                anim.SetFloat("velocita", 0.0f);
            }*/

            if (shoot && canShot)
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
