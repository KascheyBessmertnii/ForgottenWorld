//Inventory script relized based simple inventory actions
//In first interation inventory not have control limit identical items in one slot 
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private List<InventoryItem> inventory { get; set; }

    public int InventorySize => inventory.Count;

    public bool HaveSpace { get { return inventory.Any(x => x.id == 0); } }

    public Inventory(int size)
    {
        inventory = new List<InventoryItem>();
        for (int i = 0; i < size; i++)
        {
            inventory.Add(new InventoryItem());
        }
    }

    /// <summary>
    /// Adding item to inventory
    /// </summary>
    /// <param name="itemId">Id target item</param>
    /// <param name="count">Item count</param>
    public void AddItem(int itemId, int count)
    {
        InventoryItem targetSlot = GetTargetSlot(itemId);
        targetSlot.SetItem(itemId, count);
    }

    /// <summary>
    /// Remove items from target slot inventory
    /// </summary>
    /// <param name="index">Inventory slot index for items remove</param>
    public void RemoveItem(int index)
    {
        inventory[index].RemoveItem();
    }

    /// <summary>
    /// Move items from start slot to target slot
    /// </summary>
    /// <param name="startSlot">Start slot id</param>
    /// <param name="endSlot">Target slot id</param>
    public void MoveItemTo(int startSlot, int endSlot)
    {
        int startId = inventory[startSlot].id;
        int startCount = inventory[startSlot].count;

        inventory[startSlot].SetItem(inventory[endSlot].id, inventory[endSlot].count);
        inventory[endSlot].SetItem(startId, startCount);
    }

    private InventoryItem GetTargetSlot(int itemId)
    {
        //try find first slot with itemId
        InventoryItem target = inventory.FirstOrDefault(x => x.id == itemId);

        //If inventory not contains item with itemId find first free slot
        if(target == null)
        {
            target = inventory.FirstOrDefault(x => x.id == 0);
        }

        return target;
    }
}

public class InventoryItem
{
    public int id { get; private set; }
    public int count { get; private set; }

    public InventoryItem(int id = 0, int count = 0)
    {
        this.id = id;
        this.count = count;
    }

    /// <summary>
    /// Set item to slot
    /// </summary>
    /// <param name="itemId">Target item id</param>
    /// <param name="itemCount">Target item count</param>
    public void SetItem(int itemId, int itemCount)
    {
        id = itemId;
        count += itemCount;
    }

    /// <summary>
    /// Remove all items from slot
    /// </summary>
    public void RemoveItem()
    {
        id = 0;
        count = 0;
    }
}