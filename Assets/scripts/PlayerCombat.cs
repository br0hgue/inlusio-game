using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackpoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;

    private void Update()


    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()

    {
        //this is so bad but it works
        GameObject Player = GameObject.Find("Player");
        PlayerStats PlayerDamage = Player.GetComponent<PlayerStats>();
        int damage = PlayerDamage.damage.GetValue();
        //attack animation here
        Collider [] hitenemies = Physics.OverlapSphere(attackpoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitenemies)
        {
            enemy.GetComponent<CharacterStat>().TakeDamage(damage);
            Debug.Log(damage);
        }

        
    }

    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }

}
