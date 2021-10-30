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
    bool isdead;
    public override void Awake()
    {
        isdead = false;
        base.Awake();
        animator = gameObject.GetComponent<Animator>();
        //agent = enemy.GetComponent<NavMeshAgent>();
        animator.SetBool("isDying", false);
    }

    public override void TakeDamage(int damage)
    {
        animator.SetBool("isDamaged", true);
        enemy.GetComponent<enemyScripts>().damageTime = 1.5f;
        if(!isdead){
        base.TakeDamage(damage);
       Destroy(Instantiate(particles.gameObject, enemy.transform.position + Vector3.up, Quaternion.Euler(270,0,0)) as GameObject, 2f);
       }
    }
    public override void Die()
    {
        //agent.enabled = false;
        //base.Die();
        animator.SetBool("isDying", true);
        Invoke("spawnDrop", 0.5f);
        isdead = true;
        Destroy(Instantiate(particles.gameObject, enemy.transform.position + Vector3.up, Quaternion.Euler(270,0,0)) as GameObject, 2f);

        
        Destroy(gameObject, 3f);
        
    }

    void spawnDrop(){
        Vector3 plusAmount = new Vector3(0f,0.5f,0f);
        Instantiate(drop, enemy.transform.position + plusAmount, Quaternion.Euler(90,0,0));

    }
}
