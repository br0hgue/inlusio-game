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
    public int scrollPosition;

    Dictionary <inventSlot, GameObject> itemsDisplayed = new Dictionary<inventSlot, GameObject>();

    private void Start() {
        inventory = Inventory.instance;
        scrollPosition = 1;
    }
    private void Update() {
        //print(Mathf.RoundToInt(Input.mouseScrollDelta.y));
        if(Mathf.RoundToInt(Input.mouseScrollDelta.y) >= 1){
            scrollPosition++;
            if(scrollPosition >= 7){
                scrollPosition = 1;
            }
            Selected();
            
        }
        if(Mathf.RoundToInt(Input.mouseScrollDelta.y) <= -1){
            scrollPosition--;
            if(scrollPosition <= 0){
                scrollPosition = 6;
            }
         Selected();
        }

       
        
    }
    void Selected(){
        if (_slot.name == "InventorySlot ("+scrollPosition+")"){
            var image = _slot.GetComponentInChildren<Image>();
            image.rectTransform.sizeDelta = new Vector2(70,70);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.75f);
            
            if (item != null){
                item.item.inHand();

                if(item.item.item_type != 3){
                    Inventory.instance.currentItem.item.Unhand();
                    print("1");
                }
                Inventory.instance.currentItem = item;
                //print(olditem);
            } else if (item == null)
            {
                print("2");
                if (Inventory.instance.currentItem == null){
                    return;
                    }
                //remove previous item
                
                Inventory.instance.currentItem.item.Unhand();
                
                Inventory.instance.currentItem = null;
                    

            }
        } else {
            var image = _slot.GetComponentInChildren<Image>();
            image.rectTransform.sizeDelta = new Vector2(60,60);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.39f);
        }
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
        } else {
            //print ("bruh");
        }
        
    }
}
