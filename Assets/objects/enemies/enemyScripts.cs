using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyScripts : MonoBehaviour
{
    public float attackCooldown = 1f;
    public float visionRads = 10f;
    float spottime;
    public float damageTime;
    Transform target;
    CharacterStat enemy;
    NavMeshAgent agent;
    Animator animator;
    bool IsPlayerAlive = true;
    bool spotted;

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
        //if damaged wait to attack, set by TakeDamage
        damageTime -= Time.deltaTime;
        if(damageTime < 0){
            animator.SetBool("isDamaged", false);
        }

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

        
        
        float distance = Vector3.Distance(target.position, transform.position);

        attackCooldown -= Time.deltaTime;
        //check if ended attack
        if (attackCooldown < 1f && attackCooldown > 0f ){
            animator.SetBool("isAttacking", false);
            
        }
        if (distance <= visionRads)
        {
            
            //was going to do a spot thing but didnt work
            //var heading = target.position - enemy.transform.position;
            //float dot = Vector3.Dot(heading, enemy.transform.position);
            
           
            if(!spotted){
            spottime = 30f;
            }
            
            agent.SetDestination(target.position);
            animator.SetBool("isMoving", true);

            if (distance <= agent.stoppingDistance)
            {
                animator.SetBool("isMoving", false);
                if (attackCooldown < 0f && !animator.GetBool("isDamaged"))
                    {
                        Invoke("Attack", 0);
                    }
                    
            }
            
            
        } else if (spotted && distance > visionRads){
            
            agent.SetDestination(target.position);
            animator.SetBool("isMoving", true);
            
            if (distance <= agent.stoppingDistance)
            {
                animator.SetBool("isMoving", false);
                if (attackCooldown < 0f)
                    Invoke("Attack",0);
                    

            }
        } else animator.SetBool("isMoving", false);

        if(animator.GetBool("isDying")){
            CancelInvoke();
        } 
    }
    void Attack()
    {
        Invoke("TruAttack", .75f);
        animator.SetBool("isAttacking", true);
        attackCooldown = 2.5f;
       
    }

    void TruAttack(){
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