using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class damnedStats : CharacterStat
{
    Animator animator;
    //public GameObject enemy;

    public GameObject enemy;
    public GameObject drop;
    public ParticleSystem particles;

    public override void Awake()
    {
        base.Awake();
        animator = gameObject.GetComponent<Animator>();
        //agent = enemy.GetComponent<NavMeshAgent>();
        animator.SetBool("isDying", false);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
       Destroy(Instantiate(particles.gameObject, enemy.transform.position + Vector3.up, Quaternion.Euler(270,0,0)) as GameObject, 2f);
    }
    public override void Die()
    {
        //agent.enabled = false;
        //base.Die();
        animator.SetBool("isDying", true);
        Invoke("spawnDrop", 0.5f);
        Destroy(gameObject, 3f);
        
    }

    void spawnDrop(){
        Vector3 plusAmount = new Vector3(0f,0.5f,0f);
        Instantiate(drop, enemy.transform.position + plusAmount, Quaternion.Euler(90,0,0));

    }
}
