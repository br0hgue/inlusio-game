using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackpoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    Animator animator;
    bool hasAttacked;
    //float attackSpeed = 1f;
    float attackCooldown = 1.4f;
    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        attackCooldown = 0f;

    }
    private void Update()
    {
        attackCooldown -= Time.deltaTime;

        

        if (Input.GetMouseButtonDown(0) && attackCooldown <= 0f && !EventSystem.current.IsPointerOverGameObject())
        {
            Invoke("Attack", .33f);
            hasAttacked = false;
            animator.SetBool("isAttacking", true);
            attackCooldown = .7f;
        }

        if (attackCooldown <= .5f){
            animator.SetBool("isAttacking", false);
        }

        if (attackCooldown > 0f){
            hasAttacked = true;
        } 
            //Debug.Log(attackCooldown);
    }

    void Attack()
    {
        //this is so bad but it works
        GameObject Player = GameObject.Find("Player");
        PlayerStats PlayerDamage = Player.GetComponent<PlayerStats>();
        int damage = PlayerDamage.damage.GetValue();
        Debug.Log(damage);
        //attack animation here
        Collider [] hitenemies = Physics.OverlapSphere(attackpoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitenemies)
        {
            enemy.GetComponent<CharacterStat>().TakeDamage(damage);
            //Debug.Log(damage);
        }

        

        
    }

    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }

}
