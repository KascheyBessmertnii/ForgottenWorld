using UnityEngine;

public class PlayerInventoryController : PlayerInventoryUI, IGetSlotItem
{
    #region Singleton
    public static PlayerInventoryController Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion

    [Header("Inventory parameters")]
    [SerializeField, Range(5, 20)] private int inventorySize = 5;
    [Header("Key")]
    [SerializeField] private KeyCode inventoryOpenButton = KeyCode.I;

    private Inventory inventory;
    private Equipment equipment;
    private GameItemsList itemList;
    private Transform playerPos = default;

    private void OnEnable()
    {
        GameEvents.OnGetItem += GetItem;
    }

    private void OnDisable()
    {
        GameEvents.OnGetItem -= GetItem;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    private void Start()
    {
        inventory = new Inventory(inventorySize);
        equipment = new Equipment(equipmentSlotContainer.childCount);
        InitializeSlots(inventorySize, equipmentSlotContainer.childCount);

        itemList = GameItemsList.Instance;

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(inventoryOpenButton))
        {
            ShowHideInventory();
        }
    }

    private bool GetItem(GameItem item)
    {
        return item == null ? false : inventory.AddItem(item.Item.id, item.Count);
    }

    public ItemSO GetSlotItem(Slot slot)
    {
        Inventory targetInv = GetTargetInventory(slot);
        return targetInv.GetItemInSlot(slot.Index);
    }

    public ItemSO GetEquipSlotItem(int slotIndex)
    {
        int itemId = equipment.GetItemIdInSlot(slotIndex);
        return itemId == 0 ? null : itemList.GetItemByID(itemId);
    }

    public void DropItemToGround(Slot slot)
    {
        Inventory targetInv = GetTargetInventory(slot);
        var item = targetInv.GetItemInSlot(slot.Index);
        //Instantiate dropped item forward player in 0.5m
        Instantiate(item.prefab, playerPos.position + playerPos.forward * 0.5f, Quaternion.identity);
        targetInv.RemoveItem(slot.Index);
    }

    public void ChangeItemPlace(Slot startSlot, Slot endSlot)
    {
        Inventory startObj = GetTargetInventory(startSlot);
        Inventory targetObj = GetTargetInventory(endSlot);
        if (CanPlaceItem(startSlot, endSlot, startObj))
        {
            int tmpItem = startObj.GetItemIdInSlot(startSlot.Index);
            int tmpCount = startObj.GetItemsCountInSlot(startSlot.Index);

            startObj.PlaceItemInSlot(targetObj.GetItemIdInSlot(endSlot.Index), targetObj.GetItemsCountInSlot(endSlot.Index), startSlot.Index);
            targetObj.PlaceItemInSlot(tmpItem, tmpCount, endSlot.Index);
        }
    }

    private Inventory GetTargetInventory(Slot slot)
    {
        if (slot.GetSlotType() == EquipmentType.None)
            return inventory;
        return equipment;
    }

    private bool CanPlaceItem(Slot startSlot, Slot endSlot, Inventory startInv)
    {
        if (endSlot.GetSlotType() == EquipmentType.None) return true; //If move to inventory (backpack) always return true.

        var startItem = startInv.GetItemInSlot(startSlot.Index);
        return startItem.EquipmentSlot() == endSlot.GetSlotType(); //If move to eqipment and type equals return true.
    }
}
