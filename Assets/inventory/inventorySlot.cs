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

    Dictionary <inventSlot, GameObject> itemsDisplayed = new Dictionary<inventSlot, GameObject>();

    private void Start() {
        inventory = Inventory.instance;
    }

    public void AddItem(inventSlot newItem)
    { 
        item = newItem;
        icon.sprite = newItem.item.icon;
        icon.enabled = true;
        
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if(itemsDisplayed.ContainsKey(inventory.items[i])){
                   this.GetComponentInChildren<TextMeshProUGUI>().text = inventory.items[i].amount.ToString("n0");
                }
            else{ 
            var obj = Instantiate(inventory.items[i].item._object, transform); 
            this.GetComponentInChildren<TextMeshProUGUI>().text = inventory.items[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.items[i], obj);
            print(inventory.items[i].amount.ToString());}

        }

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
            //item.Use();
        }
    }
}
