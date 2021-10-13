
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    
    public Item item;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PickupItem();
        }
        void PickupItem()
        {
            bool wasPicked = Inventory.instance.Add(item, 1);

            if (wasPicked){
                //Debug.Log("Picked up " + item.name);
                Destroy(gameObject);
            }
        }

    }
    
}

    
