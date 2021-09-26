using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Food", menuName ="Inventory/Food")]
public class Food : Item
{
    public int healthRestored;
    private int playerHealth;

    
    public override void Use()
    {
        base.Use();
        ConsumableManager.instance.Consume(healthRestored);
        RemoveFromInventory();

    }
}
