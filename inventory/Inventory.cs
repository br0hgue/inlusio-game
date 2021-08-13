using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region singleton
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

    //important to make this
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("inventory full");
            return false;
        }
        items.Add(item);
        
        //no ideia but i guess it does the item change thing
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        return true;
    }
    public void Remove(Item item)
    {
        items.Remove(item);     // Remove item from list

        // Trigger callback
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

    }
}
