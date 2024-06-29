using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public Sprite Sprite_Icon;
    public string Category;
    public string Keterangan;
    public int Value;
}
