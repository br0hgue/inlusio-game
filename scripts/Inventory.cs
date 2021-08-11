using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    
    #region singleton
    // i have no idea what this does to be honest
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning(" more than one inventory instance");
            return;
        }
        instance = this;
    }

    #endregion

    // creates item list
    
    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add (Item  item)
    {
        if (items.Count >= space)
        {
            Debug.Log("inventory full");
            return false;
        }
        items.Add(item);
        return true;
    }
    public void Remove (Item item)
    {
        items.Remove(item);
    }
}
