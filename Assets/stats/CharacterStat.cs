using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public Stat damage;
    public Stat armor;
    Animator _animator;
    public int MaxHealth = 100;
    public int CurrentHealth;
    
    public virtual void Awake()
    {
        CurrentHealth = MaxHealth;
        _animator = gameObject.GetComponent<Animator>();
        _animator.SetBool("isDying", false);
        
    }

    public void Update()
    {
    
    }

    public void addHealth(int health){ 
             CurrentHealth += health;
        }
    public virtual void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        CurrentHealth -= damage;


        

        if (CurrentHealth <= 0)
        {
            Die();
            //Debug.Log("died");
        }
    }

    public virtual void Die()
    {
        _animator.SetBool("isDying", true);
        Destroy(gameObject, 3f);
    }
}