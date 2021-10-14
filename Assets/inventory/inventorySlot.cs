using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
public class inventorySlot : MonoBehaviour
{
    public Image icon;
    // Start is called before the first frame update
    inventSlot item;
    Item _item;
    Inventory inventory;
    public inventorySlot _slot;

    Dictionary <inventSlot, GameObject> itemsDisplayed = new Dictionary<inventSlot, GameObject>();

    private void Start() {
        inventory = Inventory.instance;
    }

    public void AddItem(inventSlot newItem)
    { 
        item = newItem;
        icon.sprite = newItem.item.icon;
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
            item.item.Use();
        }
    }
}
