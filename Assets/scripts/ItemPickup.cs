
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject thisObject;

    private void Update() {
        thisObject.transform.Rotate(Vector3.up, Space.World);
    }
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
            print(wasPicked);
            if (wasPicked){
                //Debug.Log("Picked up " + item.name);
                Destroy(gameObject);
            }
        }

    }
    
}

    
