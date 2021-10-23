using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Food", menuName ="Inventory/Food")]
public class Food : Item
{
    public int healthRestored;
    public GameObject playerHealth;
    private void Awake() {
       
        playerHealth = GameObject.FindGameObjectWithTag("Player");
        
        
    }
    public override void Use()
    {
        base.Use();
        ConsumableManager.instance.Consume(healthRestored);
        RemoveFromInventory();

    }

    public override bool CheckHealth()
    {
        var health = playerHealth.GetComponentInParent<PlayerStats>();
        Debug.Log(playerHealth);
        if(health.CurrentHealth == health.MaxHealth )
            return false;
        else return true;
    }
}
