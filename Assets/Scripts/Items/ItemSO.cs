//ItemSO contains all data about item
using UnityEngine;

public class ItemSO : ScriptableObject, IEquipment, IFood
{
    public new string name;
    public int id;
    public string description;
    public Sprite icon;
    public GameItem prefab;

    public virtual EquipmentType EquipmentSlot()
    {
        return EquipmentType.None;
    }

    public virtual FoodRestore Restore()
    {
        return new FoodRestore();
    }
}
