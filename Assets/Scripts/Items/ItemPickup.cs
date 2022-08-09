using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData itemData;

    void Pickup ()
    {
    
        InventoryManager.instance.Add(itemData);

        Destroy(gameObject);
        
    }

    private void OnMouseDown ()
    {
        Pickup();  
    }
}
