using System.Collections.Generic;

using UnityEngine;
using TMPro;
public class inventoryUI : MonoBehaviour
{
    public Transform ItemsParent;
    Inventory inventory;
    inventorySlot[] slots;

    //Dictionary <inventSlot, GameObject> itemsDisplayed = new Dictionary<inventSlot, GameObject>();

    //public int length = itemsDisplayed.Count;
    public GameObject InventoryUI;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = ItemsParent.GetComponentsInChildren<inventorySlot>();
    }

    /*void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
    }
    */


    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
                /*if(itemsDisplayed.ContainsKey(inventory.items[i])){
                   this.GetComponentInChildren<TextMeshProUGUI>().text = inventory.items[i].amount.ToString("n0");
                }
                else{
                    var obj = Instantiate(inventory.items[i].item._object, transform); 
                    this.GetComponentInChildren<TextMeshProUGUI>().text = inventory.items[i].amount.ToString("n0");
                    itemsDisplayed.Add(inventory.items[i], obj);
                    print(inventory.items[i].amount.ToString());
                }*/
            } else
            {
                slots[i].ClearSlot();

            }
        }
    }
    
}
    
