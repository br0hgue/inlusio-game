using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStat
{
    Animator animator;
    public HealthBarScript healthBar;

    void Start()
    {
        healthBar.SetHealth(MaxHealth);
        animator = GetComponentInChildren<Animator>();
    }
    
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        healthBar.SetHealth(CurrentHealth);
    }
    override public void Die()
    {
        animator.SetBool("isDying", true);
        Destroy(gameObject, 3.13f);
        //show death screen
    }
}
