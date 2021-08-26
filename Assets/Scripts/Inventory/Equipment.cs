public class Equipment : Inventory
{
    public Equipment(int size) : base(size)
    {
    }

    public override bool AddItem(int itemId, int count)
    {
        return false;
    }

    private bool GetItem(int itemId)
    {
        return GameItemsList.Instance.GetItemByID(itemId)?.EquipmentSlot() != EquipmentType.None;
    }
}
