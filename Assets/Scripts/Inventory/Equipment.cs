using System.Collections.Generic;

public class Equipment : Inventory
{
    public Equipment(int size) : base(size)
    {
        Inv = new List<InventorySlot>();
        for (int i = 0; i < size; i++)
        {
            Inv.Add(new EquipmentSlot());
        }
    }

    public void SetSlotType(int slotIndex, EquipmentType slotType)
    {
        Inv[slotIndex].SetSlotType(slotType);
    }

    public override bool CanPlaceItem(int itemId, int slotIndex,  int count = 1)
    {
        ItemSO item = GameItemsList.Instance.GetItemByID(itemId);

        if (item == null) return true;

        return item.EquipmentSlot() == Inv[slotIndex].GetSlotType();
    }
}

public class EquipmentSlot : InventorySlot
{
    public EquipmentType Type { get; private set; }

    public EquipmentSlot(EquipmentType slotType = EquipmentType.None, int id = 0, int count = 0)
    {
        Id = id;
        Count = count;
        Type = slotType;
    }

    public override EquipmentType GetSlotType()
    {
        return Type;
    }

    public override void SetSlotType(EquipmentType type)
    {
        Type = type;
    }
}