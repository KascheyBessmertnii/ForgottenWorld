using UnityEngine;

public class PlayerInventoryController : PlayerInventoryUI, IInventory
{
    public static PlayerInventoryController Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    [Header("Inventory parameters")]
    [SerializeField, Range(5, 20)] private int inventorySize = 5;
    [Header("Key")]
    [SerializeField] private KeyCode inventoryOpenButton = KeyCode.I;

    private Inventory inventory;
    private GameItemsList itemList;

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
        InitializeSlots(inventorySize);
        itemList = GameItemsList.Instance;
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
        if (item == null) return false;
        return inventory.AddItem(item.Item.id, item.Count);
    }

    public Sprite GetItemSprite(int slotIndex)
    {
        int itemId = inventory.GetItemIdInSlot(slotIndex);
        if (itemId == 0) return null;
        return itemList.GetItemByID(itemId).icon;
    }
}
