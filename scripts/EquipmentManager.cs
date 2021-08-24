using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region singleton
    public static EquipmentManager instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion

    public delegate void onEquipmentChanged (Equipment newItem, Equipment oldItem);
    public onEquipmentChanged OnEquipmentChanged;
    Equipment[] currentEquipment;

    private void Start()
    {
        //gets how many slots there are and i have no idea what the other one does
        int numberSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberSlots];
         
    }
    public void Equip(Equipment newItem)
    { 
        //gets the uhhhhh number of the slot?
        int slotIndex = (int)newItem.equipmentslot;

        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null)
        {
            //i guess this adds the item as olditem to help the other scripts
            oldItem = currentEquipment[slotIndex];

            Inventory.instance.Add(oldItem);
        }

        currentEquipment[slotIndex] = newItem;
    }
    public void Unequip(Equipment newItem, Equipment oldItem){
        //not currently used but will be in the future
    }

}
