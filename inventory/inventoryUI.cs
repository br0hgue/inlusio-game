using UnityEngine;

public class inventoryUI : MonoBehaviour
{
    //the items parent here is the parent of the item slots 
    public Transform ItemsParent;
    Inventory inventory;
    inventorySlot[] slots;

    public GameObject InventoryUI; 
    
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = ItemsParent.GetComponentsInChildren<inventorySlot>();
    }

    //the getbuttondown string name is determined in the project configs
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            } else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
    
