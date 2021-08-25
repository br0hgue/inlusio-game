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
        int numberSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberSlots];
         
    }
    public void Equip(Equipment newItem)
    { 
        int slotIndex = (int)newItem.equipmentslot;

        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];

            Inventory.instance.Add(oldItem);
        }

        currentEquipment[slotIndex] = newItem;
    }
    public void Unequip(Equipment newItem, Equipment oldItem){

    }

}
