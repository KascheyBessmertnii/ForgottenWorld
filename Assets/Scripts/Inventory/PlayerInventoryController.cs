using UnityEngine;

public class PlayerInventoryController : PlayerInventoryUI
{
    [Header("Inventory parameters")]
    [SerializeField, Range(5, 20)] private int inventorySize = 5;
    [Header("Key")]
    [SerializeField] private KeyCode inventoryOpenButton = KeyCode.I;

    private Inventory inventory;

    private void Start()
    {
        inventory = new Inventory(inventorySize);
        InitializeSlots(inventorySize);
    }

    private void Update()
    {
        if(Input.GetKeyDown(inventoryOpenButton))
        {
            ShowHideInventory();
        }
    }
}
