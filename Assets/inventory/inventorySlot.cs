﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class inventorySlot : MonoBehaviour
{
    public Image icon;
    // Start is called before the first frame update
    Item item;

    public void AddItem(Item newItem)
    { 
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;

    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
    public void useItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
