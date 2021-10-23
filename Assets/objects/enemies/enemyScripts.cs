using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyScripts : MonoBehaviour
{
    public float attackCooldown = 1f;
    public float visionRads = 10f;
    public float spottime;
    Transform target;
    CharacterStat enemy;
    NavMeshAgent agent;
    Animator animator;
    bool IsPlayerAlive = true;
    public bool spotted;

    void Start()
    {
        spottime = -1f;
        enemy = GetComponent<CharacterStat>();
        target = PlayerManager.instance.player.transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //Debug.Log('1');
    }

    // Update is called once per frame
    void Update()
    {
        
        if (spottime < 0){
            spotted = false;
        } else spotted = true;

        spottime -= Time.deltaTime;
      
        if (IsPlayerAlive == false)
            return;

        if (target == null)
        {
            IsPlayerAlive = false;
            return;
        }

        //print(spotted);
        
        float distance = Vector3.Distance(target.position, transform.position);

        attackCooldown -= Time.deltaTime;

        if (attackCooldown < 1f && attackCooldown > 0f ){
            animator.SetBool("isAttacking", false);
            //print("yes");
        }
        if (distance <= visionRads)
        {
            //agent.isStopped = false;

            var heading = target.position - enemy.transform.position;
            float dot = Vector3.Dot(heading, enemy.transform.position);
            
            //if (dot >= .7f){
            if(!spotted){
            //spotted = true;
            spottime = 30f;
            }
            agent.SetDestination(target.position);
            animator.SetBool("isMoving", true);

            if (distance <= agent.stoppingDistance)
            {
                animator.SetBool("isMoving", false);
                if (attackCooldown < 0f)
                    Invoke("Attack", 0);
                    //animator.SetBool("isattacking", false);
                    //print (attackCooldown);
            }
            
            
        } else if (spotted && distance > visionRads){
            //agent.isStopped = false;
            agent.SetDestination(target.position);
            animator.SetBool("isMoving", true);
            //print(spotted);
            if (distance <= agent.stoppingDistance)
            {
                animator.SetBool("isMoving", false);
                if (attackCooldown < 0f)
                    Invoke("Attack",0);
                    //animator.SetBool("isattacking", false);
                    //print (attackCooldown);

            }
        } else animator.SetBool("isMoving", false);

        if(animator.GetBool("isDying")){
            CancelInvoke();
        }
        //agent.isStopped = true;

        
    }
    void Attack()
    {
        Invoke("TruAttack", .75f);
        animator.SetBool("isAttacking", true);
        attackCooldown = 2.5f;
       
    }

    void TruAttack(){
        //CharacterStat character = GetComponent<CharacterStat>();
        int damage = enemy.damage.GetValue();
        PlayerStats playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        playerhealth.TakeDamage(damage);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRads);
    } 
}