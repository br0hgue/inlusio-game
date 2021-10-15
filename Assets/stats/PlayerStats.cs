using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStat
{
    Animator animator;
    public HealthBarScript healthBar;
    

    public override void Awake()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetHealth(MaxHealth);
        animator = GetComponentInChildren<Animator>();
    }
    
    public override void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        //Debug.Log(damage);
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
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
