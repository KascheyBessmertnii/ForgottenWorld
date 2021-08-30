//Inventory script relized based simple inventory actions
//In first interation inventory not have control limit identical items in one slot 
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    protected List<InventorySlot> Inv { get; set; }

    public int InventorySize => Inv.Count;

    public bool HaveSpace { get { return Inv.Any(x => x.Id == 0); } }

    public Inventory(int size)
    {
        Inv = new List<InventorySlot>();
        for (int i = 0; i < size; i++)
        {
            Inv.Add(new InventorySlot());
        }
    }

    public virtual bool CanPlaceItem(int itemId, int slotIndex,  int count = 1)
    {
        return GetTargetSlot(itemId) != null;
    }

    /// <summary>
    /// Adding item to inventory
    /// </summary>
    /// <param name="itemId">Id target item</param>
    /// <param name="count">Item count</param>
    /// <returns>true if getting item, false if cant get item</returns>
    public virtual bool AddItem(int itemId, int count)
    {
        InventorySlot targetSlot = GetTargetSlot(itemId);
        if(targetSlot != null)
        {
            targetSlot.SetItem(itemId, count);
            GameEvents.OnUpdateSlotImage?.Invoke();
        }

        return targetSlot != null;
    }
    public virtual void PlaceItemInSlot(int itemId, int count, int slotIndex)
    {
        Inv[slotIndex].SetItem(itemId, count);
    }
    /// <summary>
    /// Remove items from target slot inventory
    /// </summary>
    /// <param name="index">Inventory slot index for items remove</param>
    public void RemoveItem(int index)
    {
        Inv[index].RemoveItem();
    }
    /// <summary>
    /// Move items from start slot to target slot
    /// </summary>
    /// <param name="startSlot">Start slot index</param>
    /// <param name="endSlot">Target slot index</param>
    public void MoveItemTo(int startSlot, int endSlot)
    {
        int startId = Inv[startSlot].Id;
        int startCount = Inv[startSlot].Count;

        Inv[startSlot].SetItem(Inv[endSlot].Id, Inv[endSlot].Count);
        Inv[endSlot].SetItem(startId, startCount);
    }
    public int GetItemIdInSlot(int slotIndex)
    {
        return Inv?[slotIndex].Id ?? 0;
    }
    public ItemSO GetItemInSlot(int slotIndex)
    {
        return slotIndex > Inv.Count ? null : GameItemsList.Instance.GetItemByID(Inv[slotIndex].Id);
    }
    public int GetItemsCountInSlot(int slotIndex)
    {
        return Inv?[slotIndex].Count ?? 0;
    }

    protected virtual InventorySlot GetTargetSlot(int itemId)
    {
        //try find first slot with itemId
        InventorySlot target = Inv.FirstOrDefault(x => x.Id == itemId);

        //If inventory not contains item with itemId find first free slot
        return target ?? Inv.FirstOrDefault(x => x.Id == 0);
    }
}

public class InventorySlot
{
    public int Id { get; set; }
    public int Count { get; set; }

    public InventorySlot(int id = 0, int count = 0)
    {
        this.Id = id;
        this.Count = count;
    }

    /// <summary>
    /// Set item to slot
    /// </summary>
    /// <param name="itemId">Target item id</param>
    /// <param name="itemCount">Target item count</param>
    public virtual void SetItem(int itemId, int itemCount)
    {
        Id = itemId;
        Count += itemCount;
    }

    /// <summary>
    /// Remove all items from slot
    /// </summary>
    public virtual void RemoveItem()
    {
        Id = 0;
        Count = 0;
    }

    public virtual EquipmentType GetSlotType()
    {
        return EquipmentType.None;
    }

    public virtual void SetSlotType(EquipmentType type) { }
}