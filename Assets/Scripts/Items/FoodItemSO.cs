using UnityEngine;

[CreateAssetMenu(menuName = "My game/Items/Food")]
public class FoodItemSO : ItemSO
{
    [SerializeField] private FoodRestore food;

    public override FoodRestore Restore()
    {
        return food;
    }

    public override string GetItemInfo()
    {
        string result = base.GetItemInfo();
        result += string.Format("\nУталяет {0} единиц голода", food.value.ToString());
        return result;
    }
}

[System.Serializable]
public class FoodRestore
{
    public FoodRestoreType restore = FoodRestoreType.None;
    public int value = 0;

    public FoodRestore(FoodRestoreType type = FoodRestoreType.None, int value = 0)
    {
        restore = type;
        this.value = value;
    }
}