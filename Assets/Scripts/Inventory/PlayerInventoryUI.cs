using UnityEngine;

public class PlayerInventoryUI : MonoBehaviour
{
    [Header("Inventory UI section")]
    [SerializeField] private Transform inventorySlotsContainer;

    protected void InitializeSlots(int inventorySize)
    {
        if (inventorySlotsContainer == null)
        {
            Debug.LogError("Not set inventory slots container!");
            return;
        }

        //Set visibility for inventory slots by inventory size
        for (int i = 0; i < inventorySlotsContainer.childCount; i++)
        {
            SetSlotState(i, i < inventorySize);
        }
    }

    protected void ShowHideInventory()
    {
        inventorySlotsContainer.parent.gameObject.SetActive(!inventorySlotsContainer.parent.gameObject.activeSelf);
    }

    private void SetSlotState(int slotIndex, bool state)
    {
        inventorySlotsContainer.GetChild(slotIndex).gameObject.SetActive(state);
    }
}
