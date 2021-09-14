using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipmentslot;

    public MeshRenderer mesh;
    
    public int damageMod;
    public int armorMod;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
        
    }
}

public enum EquipmentSlot
{
    Weapon, Armor, Other
}