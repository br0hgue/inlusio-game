using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Inventory : MonoBehaviour
{
    #region singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning(" more than one inventory instance");
            return;
        }
        instance = this;
    }

    #endregion
    
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public delegate void ItemRemoved();
    public ItemRemoved onitemremovedCallback;

    Transform hand;
    public inventSlot slotItem;
    public inventSlot currentItem;
    public MeshRenderer currentMeshItem;
    public SkinnedMeshRenderer targetMesh;

    public int space = 20;

    public List<inventSlot> items = new List<inventSlot>();
    private void Start() {
        hand = GameObject.Find("hand.R").transform;
    }
    private void Update() {
         if(Input.GetMouseButtonDown(1)){
            //print("eggs");
            currentItem.item.Use();
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            Instantiate(currentItem.item._object, PlayerManager.instance.player.transform.position + Vector3.forward, Quaternion.identity);
            Remove(currentItem.item, 1);
        }
    }

    public void equipInHand (Item item){
        for (int i = 0; i < hand.childCount; i++){
         Transform child = hand.GetChild(i);
         //print(item);
         if (child.name == item.name && child.GetComponent<MeshRenderer>() == true){
             child.GetComponent<MeshRenderer>().enabled = true;
         }
        else if (child.name != item.name && child.GetComponent<MeshRenderer>() == true)
             {child.GetComponent<MeshRenderer>().enabled = false;}
        else if(child.GetComponent<MeshRenderer>() == false)
            return;
        }
        //MeshRenderer newMesh = Instantiate<MeshRenderer>(item.mesh);
        //newMesh.transform.parent = targetMesh.transform;
        //currentMeshItem = newMesh;
        //print("hmmmmm yes");

    }

    public void takOutOfHand(){
        for (int i = 0; i < hand.childCount; i++){
        Transform child = hand.GetChild(i);
        if (child.GetComponent<MeshRenderer>() == true){
             child.GetComponent<MeshRenderer>().enabled = false;
             }
        
        }
    
    }


    public bool Add(Item _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].item == _item && items[i].item.item_type == 1){
                items[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }

        if (!hasItem){
            items.Add(new inventSlot(_item, _amount));
        }

        if (items.Count >= space)
        {
            //Debug.Log("inventory full");
            return false;
        }
        
        
        if (onItemChangedCallback != null)
            //Debug.Log("broh momento");
            onItemChangedCallback.Invoke();

        return true;
    }
    public void Remove(Item item, int amount)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].item.name == item.name){
                items[i].amount -= 1;
                if (items[i].amount == 0){
                    items.RemoveAt(i);
                }
            }
        }     // Remove item from list

        // Trigger callback
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

    }
}

[System.Serializable]
public class inventSlot{
    public Item item;
    public int amount;
    public inventSlot(Item _item, int _amount){
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value){
        amount += value;
    }
    
}