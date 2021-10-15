using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipmentslot;

    //public MeshRenderer mesh;
    
    public int damageMod;
    public int armorMod;

    public override void inHand()
    {
       // put in hand
        if (this.equipmentslot == EquipmentSlot.Weapon){
            EquipmentManager.instance.Equip(this);
            Debug.Log("wooooo yeaaa baby");

        }
    }
    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
    }

}

public enum EquipmentSlot
{
    Weapon, Armor, Other
}