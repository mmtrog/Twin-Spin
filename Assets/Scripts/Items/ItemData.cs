using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class ItemData : ScriptableObject
{
    public int id;

    public string itemName;

    public int value;

    public Sprite icon;
}
