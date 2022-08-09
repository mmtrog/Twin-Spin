using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<ItemData> items = new List<ItemData>();

    public Transform itemContent;

    public GameObject inventoryItem;

    public Toggle enableRemove;

    public InventoryItemController[] inventoryItems;

    public ItemData[] foodList;

    private void Awake ()
    {
        instance = this;

        InventoryData data = SaveSystem.LoadInventory();

        if (data != null)
        {
            for (int i = 0; i < data.listItems.Length; i++)
            {
                for (int j = 0; j < foodList.Length; j++)
                {
                    if (data.listItems[i] == foodList[j].itemName)
                        
                    Add(foodList[j]);
                }
            }
        }
    }

    private void Update ()
    {
        EnableItemsRemove();
    }

    public void Add (ItemData item)
    {
        items.Add (item);

        SaveSystem.SaveInventory(items);
    }

    public void Remove (ItemData item)
    {
        items.Remove (item);

        SaveSystem.SaveInventory(items);

    }

    public void ListItems ()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);

            var itemName = obj.transform.Find("Text").GetComponent<Text>();

            var itemIcon = obj.transform.Find("Image").GetComponent<Image>();

            var removeButton = obj.transform.Find("RemoveButton").gameObject;

            itemName.text = item.itemName;

            itemIcon.sprite = item.icon;

            if (enableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);  
            }
        }  
        
        SetInventoryItems();
    }

    public void ResetInventory ()
    {
        foreach (Transform child in itemContent)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void EnableItemsRemove ()
    {

        if (enableRemove.isOn)
        {

            foreach (Transform item in itemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }

        }

        else
        {

            foreach (Transform item in itemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }

        }

    }

    public void SetInventoryItems ()
    {

        inventoryItems = itemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < items.Count; i++)
        {

            inventoryItems[i].AddItem(items[i]);
        
        }
    
    }
}
