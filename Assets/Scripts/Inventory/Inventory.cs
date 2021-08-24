//Inventory script relized based simple inventory actions
//In first interation inventory not have control limit identical items in one slot 
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private List<InventoryItem> Inv { get; set; }

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
    public bool AddItem(int itemId, int count)
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
    /// <param name="startSlot">Start slot id</param>
    /// <param name="endSlot">Target slot id</param>
    public void MoveItemTo(int startSlot, int endSlot)
    {
        int startId = Inv[startSlot].Id;
        int startCount = Inv[startSlot].Count;

        Inv[startSlot].SetItem(Inv[endSlot].Id, Inv[endSlot].Count);
        Inv[endSlot].SetItem(startId, startCount);
    }

    private InventoryItem GetTargetSlot(int itemId)
    {
        //try find first slot with itemId
        InventoryItem target = Inv.FirstOrDefault(x => x.Id == itemId);

        //If inventory not contains item with itemId find first free slot
        if(target == null)
        {
            target = Inv.FirstOrDefault(x => x.Id == 0);
        }

        return target;
    }

    public int GetItemIdInSlot(int slotIndex)
    {
        if (slotIndex > Inv.Count) return 0;
        return Inv[slotIndex].Id;
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