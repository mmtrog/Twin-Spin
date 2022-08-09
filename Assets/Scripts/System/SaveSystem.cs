using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static string[] listItems;         

    public static void SaveInventory (List<ItemData> dataInput)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/data.fun";

        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

        InventoryData data = new InventoryData(dataInput);

        formatter.Serialize(stream, data);

        stream.Close();
    
    }

    public static InventoryData LoadInventory ()
    {

        string path = Application.persistentDataPath + "/data.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            InventoryData data = formatter.Deserialize(stream) as InventoryData;

            stream.Close();

            return data;
        }
        else
        {
        
            Debug.Log("Lost data saving path in " + path);

            return null;
        
        }
                            
    }

}
