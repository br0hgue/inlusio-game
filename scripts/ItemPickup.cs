
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    
    public Item item;
    void OnTriggerEnter(Collider collider)
    {
        //important to note that it is ONLY for triggers, not usual objects
        
        if (collider.gameObject.tag == "Player")
        {
            PickupItem();
        }
        void PickupItem()
        {
            //adds to inventory
            bool wasPicked = Inventory.instance.Add(item);

            if (wasPicked){
                Debug.Log("Picked up " + item.name);
                Destroy(gameObject);
            }
        }

    }
    
}

    
