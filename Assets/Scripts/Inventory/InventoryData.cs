using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData
{ 
    public string[] listItems = new string[1000];


    public InventoryData (List<ItemData> items)
    {
        int i = 0;

        if (items != null)
        {
            foreach (ItemData item in items)
            {
                if (item != null)
                {
                    listItems[i] = item.itemName;
                    i++;
                }
            }

            i = 0;
        }
    }

}
