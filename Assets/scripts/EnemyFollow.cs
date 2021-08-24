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
    

    bool IsPlayerAlive = true;

    void Start()
    {
        target = PlayerManager.instance.player.transform;

        agent = GetComponent<NavMeshAgent>();
        Debug.Log('1');
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
            if (distance <= agent.stoppingDistance)
            {
                enemy = GameObject.Find("Enemy").GetComponent<CharacterStat>();
                print(enemy);
                CharacterStat character = GetComponent<CharacterStat>();
                int damage = enemy.damage.GetValue();
                print(damage);
                if (attackCooldown < 0f)
                    Attack(damage);

            }
        }
    }
    void Attack(int damage)
    {
        PlayerStats playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        playerhealth.TakeDamage(damage);
        attackCooldown = 1f;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRads);
    }
}