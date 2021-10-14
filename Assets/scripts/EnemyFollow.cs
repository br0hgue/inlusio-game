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

                if (attackCooldown == 0f){
                    animator.SetBool("isattacking", false);
                    print(animator.GetBool("isattacking"));
                }
            }
        } else animator.SetBool("isMoving", false);
    }
    void Attack()
    {
        enemy = GameObject.Find("Enemy").GetComponent<CharacterStat>();
                
        CharacterStat character = GetComponent<CharacterStat>();
        int damage = enemy.damage.GetValue();
        PlayerStats playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        animator.SetBool("isattacking", true);
        playerhealth.TakeDamage(damage);
        attackCooldown = 1f;
       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRads);
    }
}