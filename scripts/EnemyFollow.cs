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
        //get the target
        target = PlayerManager.instance.player.transform;

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
            //walk there
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                //not ideal methood but it works
                enemy = GameObject.Find("Enemy").GetComponent<CharacterStat>();
                print(enemy);
                CharacterStat character = GetComponent<CharacterStat>();
                int damage = enemy.damage.GetValue();
                //print(damage);
                if (attackCooldown < 0f)
                    //insert the animation here
                    Attack(damage);

            }
        }
    }
    void Attack(int damage)
    {
        //or put the animation here, i guess here makes more sense
        PlayerStats playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        playerhealth.TakeDamage(damage);
        attackCooldown = 1f;
    }
    private void OnDrawGizmosSelected()
    {
        //this is just for the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRads);
    }
}
