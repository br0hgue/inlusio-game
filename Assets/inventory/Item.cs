using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int itemAmount = 1;
    new public string name = "new item";
    public Sprite icon = null;

    public virtual void Use()
    {
        Debug.Log("used " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }


}
