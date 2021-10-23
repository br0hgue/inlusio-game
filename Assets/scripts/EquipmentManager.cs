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

    public PlayerStats playerstat;

    public delegate void onEquipmentChanged (Equipment newItem, Equipment oldItem);
    public onEquipmentChanged OnEquipmentChanged;
    //public SkinnedMeshRenderer targetMesh;
    Equipment[] currentEquipment;
    //MeshRenderer[] currentMeshes; 
    private void Start()
    {
        int numberSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberSlots];
        //currentMeshes = new MeshRenderer[numberSlots];
         
    }
    public void Equip(Equipment newItem)
    { 
        int slotIndex = (int)newItem.equipmentslot;

        playerstat.damage.baseValue += newItem.damageMod;
        playerstat.armor.baseValue += newItem.armorMod;

        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null)
        {
            //Debug.Log(playerstat.damage.GetValue());
            oldItem = currentEquipment[slotIndex];
            playerstat.damage.baseValue -= oldItem.damageMod;
            playerstat.armor.baseValue -= oldItem.armorMod;
            //Inventory.instance.Add(oldItem);
        }
        /*
        not sure if i will equip the items physically here or in Equipment.cs
        
        if(newItem.equipmentslot == EquipmentSlot.Weapon){
            //equip physiscally
            print("yay its a danger stick!");

        }*/

        //Transform bone = gameObject.transform.Find("metarig/spine/spine.002/spine.003/shoulder.L/upper_arm.L/forearm.L/hand.L");

        currentEquipment[slotIndex] = newItem;
        /* MeshRenderer newMesh = Instantiate<MeshRenderer>(newItem.mesh);
        newMesh.transform.parent = bone;
        newMesh.gameObject.transform.localPosition = Vector3.zero;
        newMesh.transform.localRotation = Quaternion.identity;
        newMesh.transform.localScale = Vector3.one;
        currentMeshes[slotIndex] = newMesh;*/

    }
    public void Unequip(int slotIndex){
            

            if (currentEquipment[slotIndex] != null){
                //if (currentMeshes[slotIndex] != null){
                    //Destroy(currentMeshes[slotIndex].gameObject);
                //}
                Equipment oldItem = currentEquipment[slotIndex];
                //Inventory.instance.Add(oldItem);
                
                playerstat.damage.baseValue -= oldItem.damageMod;
                playerstat.armor.baseValue -= oldItem.armorMod;

                currentEquipment[slotIndex] = null;
                if(oldItem.equipmentslot == EquipmentSlot.Weapon){
                
                //print("the danger stick is no longer equipped");
        }

            }
    }

    public void UnequipAll(){
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }    
}
