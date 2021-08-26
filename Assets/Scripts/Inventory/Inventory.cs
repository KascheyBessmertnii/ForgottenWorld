//Inventory script relized based simple inventory actions
//In first interation inventory not have control limit identical items in one slot 
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    protected List<InventoryItem> Inv { get; set; }

    public int InventorySize => Inv.Count;

    public bool HaveSpace { get { return Inv.Any(x => x.Id == 0); } }

    public Inventory(int size)
    {
        Inv = new List<InventoryItem>();
        for (int i = 0; i < size; i++)
        {
            Inv.Add(new InventoryItem());
        }
    }

    /// <summary>
    /// Adding item to inventory
    /// </summary>
    /// <param name="itemId">Id target item</param>
    /// <param name="count">Item count</param>
    /// <returns>true if getting item, false if cant get item</returns>
    public virtual bool AddItem(int itemId, int count)
    {
        InventoryItem targetSlot = GetTargetSlot(itemId);
        if(targetSlot != null)
        {
            targetSlot.SetItem(itemId, count);
            GameEvents.OnUpdateSlotImage?.Invoke();
            return true;
        }
        return false;
    }
    public virtual void PlaceItemInSlot(int itemId, int count, int slotIndex)
    {
        Inv[slotIndex] = new InventoryItem(itemId, count);
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
        if (slotIndex > Inv.Count) return null;
        return GameItemsList.Instance.GetItemByID(Inv[slotIndex].Id);
    }
    public int GetItemsCountInSlot(int slotIndex)
    {
        return Inv?[slotIndex].Count ?? 0;
    }
    
    protected virtual InventoryItem GetTargetSlot(int itemId)
    {
        //try find first slot with itemId
        InventoryItem target = Inv.FirstOrDefault(x => x.Id == itemId);

        //If inventory not contains item with itemId find first free slot
        return target ?? Inv.FirstOrDefault(x => x.Id == 0);
    }
}

public class InventoryItem
{
    public int Id { get; private set; }
    public int Count { get; private set; }

    public InventoryItem(int id = 0, int count = 0)
    {
        this.Id = id;
        this.Count = count;
    }

    /// <summary>
    /// Set item to slot
    /// </summary>
    /// <param name="itemId">Target item id</param>
    /// <param name="itemCount">Target item count</param>
    public void SetItem(int itemId, int itemCount)
    {
        Id = itemId;
        Count += itemCount;
    }

    /// <summary>
    /// Remove all items from slot
    /// </summary>
    public void RemoveItem()
    {
        Id = 0;
        Count = 0;
    }
}