using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public GameObject _object;
    
    public MeshRenderer mesh;
    public int item_type = 1;
    new public string name = "new item";
    public Sprite icon = null;

   

    public virtual void inHand(){
        Inventory.instance.equipInHand(this);
        //when selected in hotbar put the item in the hand
        //Debug.Log("in hand");
    }

    public virtual void Unhand(){
        Inventory.instance.takOutOfHand();
        //take out the item that was previously
        //Debug.Log("took out");
    }
    public virtual void Use()
    {
        Debug.Log("used " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this, 1);
    }

    public virtual bool CheckHealth(){
        return false;
    }

}
