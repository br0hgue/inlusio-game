using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyFollow : MonoBehaviour
{
    public float attackCooldown = 1f;
    public float visionRads = 10f;
    Transform target;
    CharacterStat enemy;
    NavMeshAgent agent;
    Animator animator;
    bool IsPlayerAlive = true;

    void Start()
    {
        enemy = GetComponent<CharacterStat>();
        target = PlayerManager.instance.player.transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //Debug.Log('1');
    }

    // Update is called once per frame
    void Update()
    {
      
        if (IsPlayerAlive == false)
            return;

        if (target == null)
        {
            IsPlayerAlive = false;
            return;
        }

        
        float distance = Vector3.Distance(target.position, transform.position);

        attackCooldown -= Time.deltaTime;

        if (attackCooldown < 1f && attackCooldown > 0f ){
            animator.SetBool("isAttacking", false);
            //print("yes");
        }
        if (distance <= visionRads)
        {
            
            agent.SetDestination(target.position);
            animator.SetBool("isMoving", true);

            if (distance <= agent.stoppingDistance)
            {
                animator.SetBool("isMoving", false);
                if (attackCooldown < 0f)
                    Attack();
                    //animator.SetBool("isattacking", false);
                    //print (attackCooldown);

            }
        } else animator.SetBool("isMoving", false);
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