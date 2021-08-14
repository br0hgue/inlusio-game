using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public Stat damage;
    public int MaxHealth = 100;
    public int CurrentHealth { get; set; }
    
    void Awake()
    {
        CurrentHealth = MaxHealth;
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {

        CurrentHealth -= damage;

        

        if (CurrentHealth <= 0)
        {
            
            Die();
            Debug.Log("died");
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
