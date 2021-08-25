using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public Stat damage;
    public Stat armor;
    public int MaxHealth = 100;
    public int CurrentHealth { get; set; }
    
    void Awake()
    {
        CurrentHealth = MaxHealth;
        
    }

    void Update()
    {
        
    }

    public virtual void TakeDamage(int damage)
    {
        
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        CurrentHealth -= damage;

        

        if (CurrentHealth <= 0)
        {
            
            Die();
            Debug.Log("died");
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
        //maybe we will do the neutralize thing here or we will do diferently to each class, then we will override it
    }
}