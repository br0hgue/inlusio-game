using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStat
{
    public HealthBarScript healthBar;

    void Start()
    {
        healthBar.SetHealth(MaxHealth);
    }
    
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        healthBar.SetHealth(CurrentHealth);
    }
    override public void Die()
    {
        Destroy(gameObject);
        //show death screen
    }
}
