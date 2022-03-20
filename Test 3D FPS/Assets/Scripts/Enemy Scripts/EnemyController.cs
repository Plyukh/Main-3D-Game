using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState 
{
    SLEEP,
    GETUP,
    PATROL,
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour {

    private EnemyAnimator enemy_Anim;
    private NavMeshAgent navAgent;

    private EnemyState enemy_State;

    public float walk_Speed = 0.5f;
    public float run_Speed = 4f;
    public float rotation_Speed;

    public float chase_Distance = 7f;
    private float current_Chase_Distance;
    public float attack_Distance = 1.8f;
    public float chase_After_Attack_Distance = 2f;

    public float patrol_Radius_Min = 20f, patrol_Radius_Max = 60f;
    public float patrol_For_This_Time = 15f;
    private float patrol_Timer;

    public float wait_Before_Attack = 2f;
    private float attack_Timer;

    private Transform target;

    public GameObject attack_Point;

    private AudioSource audioSource;

    [SerializeField] private AudioClip[] clips;

    void Awake()
    {
        enemy_Anim = GetComponent<EnemyAnimator>();
        navAgent = GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () 
    {


        patrol_Timer = patrol_For_This_Time;

        // when the enemy first gets to the player
        // attack right away
        attack_Timer = wait_Before_Attack;

        // memorize the value of chase distance
        // so that we can put it back
        current_Chase_Distance = chase_Distance;

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (enemy_State == EnemyState.SLEEP)
        {
            Sleep();
        }

        if (enemy_State == EnemyState.GETUP)
        {
            GetUp();
        }

        if (enemy_State == EnemyState.PATROL) 
        {
            Patrol();
        }

        if(enemy_State == EnemyState.CHASE)
        {
            Chase();
        }

        if (enemy_State == EnemyState.ATTACK) 
        {
            Attack();
        }
    }

    void Sleep()
    {
        navAgent.isStopped = true;

        if (Vector3.Distance(transform.position, target.position) <= chase_Distance/2)
        {
            enemy_Anim.Walk(false);

            audioSource.clip = clips[0];
            audioSource.Play();

            enemy_State = EnemyState.CHASE;
        }
    }

    public void GetSleep()
    {
        enemy_State = EnemyState.SLEEP;
        enemy_Anim.Sleep(true);
    }

    public void GetUp()
    {
        enemy_Anim.Sleep(false);
    }

    void Patrol()
    {

        // tell nav agent that he can move
        navAgent.isStopped = false;
        navAgent.speed = walk_Speed;

        // add to the patrol timer
        patrol_Timer += Time.deltaTime;

        if(patrol_Timer > patrol_For_This_Time) {

            SetNewRandomDestination();

            patrol_Timer = 0f;

        }

        if(navAgent.velocity.sqrMagnitude > 0) {
        
            enemy_Anim.Walk(true);
        
        } else {

            enemy_Anim.Walk(false);

        }

        // test the distance between the player and the enemy
        if(Vector3.Distance(transform.position, target.position) <= chase_Distance) {

            enemy_Anim.Walk(false);

            audioSource.clip = clips[0];
            audioSource.Play();

            enemy_State = EnemyState.CHASE;
        }
    } // patrol

    void Chase() {

        // enable the agent to move again
        navAgent.isStopped = false;
        navAgent.speed = run_Speed;

        enemy_Anim.Sleep(false);

        // set the player's position as the destination
        // because we are chasing(running towards) the player
        navAgent.SetDestination(target.position);

        if (navAgent.velocity.sqrMagnitude > 0) {

            enemy_Anim.Run(true);

        } else {

            enemy_Anim.Run(false);

        }

        // if the distance between enemy and player is less than attack distance
        if(Vector3.Distance(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), target.position) <= attack_Distance) {
            // stop the animations
            enemy_Anim.Run(false);
            enemy_Anim.Walk(false);
            enemy_State = EnemyState.ATTACK;

            // reset the chase distance to previous
            if(chase_Distance != current_Chase_Distance) {
                chase_Distance = current_Chase_Distance;
            }

        } else if(Vector3.Distance(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), target.position) > chase_Distance) {
            // player run away from enemy

            // stop running
            enemy_Anim.Run(false);

            enemy_State = EnemyState.PATROL;

            // reset the patrol timer so that the function
            // can calculate the new patrol destination right away
            patrol_Timer = patrol_For_This_Time;

            // reset the chase distance to previous
            if (chase_Distance != current_Chase_Distance) {
                chase_Distance = current_Chase_Distance;
            }


        } // else

    } // chase

    void Attack() {

        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;

        attack_Timer += Time.deltaTime;

        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotation_Speed);

        if (attack_Timer > wait_Before_Attack)
        {

            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.TransformDirection(Vector3.back), attack_Distance, LayerMask.GetMask("Player")))
            {
                enemy_Anim.BackAttack();
            }
            else if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z - 0.5f), transform.TransformDirection(Vector3.right), attack_Distance, LayerMask.GetMask("Player")))
            {
                enemy_Anim.RightAttack();
            }
            else if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z - 0.5f), transform.TransformDirection(Vector3.left), attack_Distance, LayerMask.GetMask("Player")))
            {
                enemy_Anim.LeftAttack();
            }
            else
            {
                if(target.GetComponent<PlayerMovement>().speed > 2)
                {
                    enemy_Anim.JumpAttack();
                }
                else
                {
                    enemy_Anim.Attack();
                }
            }

            audioSource.clip = clips[1];
            audioSource.Play();

            attack_Timer = 0f;

        }

        if(Vector3.Distance(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), target.position) >
           attack_Distance + chase_After_Attack_Distance) 
        {
            enemy_State = EnemyState.CHASE;
        }


    } // attack

    void SetNewRandomDestination() {

        float rand_Radius = Random.Range(patrol_Radius_Min, patrol_Radius_Max);

        Vector3 randDir = Random.insideUnitSphere * rand_Radius;
        randDir += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDir, out navHit, rand_Radius, -1);

        navAgent.SetDestination(navHit.position);

    }

    void Turn_On_AttackPoint() {
        attack_Point.SetActive(true);
    }

    void Turn_Off_AttackPoint() {
        if (attack_Point.activeInHierarchy) {
            attack_Point.SetActive(false);
        }
    }

    void GetUpTrigger()
    {
        enemy_State = EnemyState.PATROL;
    }

    public EnemyState Enemy_State {
        get; set;
    }

} // class


































