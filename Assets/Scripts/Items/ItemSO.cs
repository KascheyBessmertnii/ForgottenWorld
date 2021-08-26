//ItemSO contains all data about item
using UnityEngine;

public class ItemSO : ScriptableObject, IEquipment, IFood, IGetItemInfo
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

    public virtual string GetItemInfo()
    {
        return string.Format("{0}\n{1}", name, description);
    }

    public virtual FoodRestore Restore()
    {
        return new FoodRestore();
    }
}
