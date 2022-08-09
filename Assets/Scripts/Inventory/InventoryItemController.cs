using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    ItemData item;

    public Button removeButton;

    public void RemoveItem ()
    {
        InventoryManager.instance.Remove(item);            

        Destroy(gameObject);
    }

    public void AddItem (ItemData newItem)
    {
        item = newItem;
    }
}
