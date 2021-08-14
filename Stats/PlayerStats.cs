using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Stat damage;
    public int MaxHealth = 100;
    public int CurrentHealth { get; set; }
    public HealthBarScript healthBar;

    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetHealth(MaxHealth);
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
        healthBar.SetHealth(CurrentHealth);
    }
    void Die()
    {
        Destroy(gameObject);
        //show death screen
    }
}
