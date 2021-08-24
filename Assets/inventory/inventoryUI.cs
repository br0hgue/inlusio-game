using UnityEngine;

public class inventoryUI : MonoBehaviour
{
    public Transform ItemsParent;
    Inventory inventory;
    inventorySlot[] slots;

    public GameObject InventoryUI;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = ItemsParent.GetComponentsInChildren<inventorySlot>();
    }

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
    
