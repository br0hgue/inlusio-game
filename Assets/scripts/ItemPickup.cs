
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    
    public Item item;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PickupItem();
        }
        void PickupItem()
        {
            bool wasPicked = Inventory.instance.Add(item);

            if (wasPicked){
                Debug.Log("Picked up " + item.name);
                Destroy(gameObject);
            }
        }

    }
    
}

    
