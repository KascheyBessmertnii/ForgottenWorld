using UnityEngine;

public class PlayerInventoryUI : MonoBehaviour
{
    [Header("Inventory UI section")]
    [SerializeField] protected Transform inventorySlotsContainer = default;
    [SerializeField] protected Transform equipmentSlotContainer = default;


    /// <summary>
    /// Initialize player inventory and equipments slots
    /// </summary>
    /// <param name="inventorySize">Current player inventory size</param>
    /// <param name="equipmentSize">Current player equipment size</param>
    protected void InitializeSlots(int inventorySize, int equipmentSize)
    {
        if (inventorySlotsContainer == null)
        {
            Debug.LogError("Not set inventory slots container!");
            return;
        }

        if (equipmentSlotContainer == null)
        {
            Debug.LogError("Not set equipment slots panel!");
            return;
        }

        SetSlotsState(inventorySlotsContainer, inventorySize);
        SetSlotsState(equipmentSlotContainer, equipmentSize);
    }

    protected void InitializeEquipmentSlotsType(int equipmentSize, ref Equipment equipment)
    {
        for (int i = 0; i < equipmentSize; i++)
        {
            var slotType = equipmentSlotContainer.GetChild(i).gameObject.GetComponent<ISlot>().GetSlotType();
            equipment.SetSlotType(i, slotType);
        }
    }

    protected void ShowHideInventory()
    {
        inventorySlotsContainer.parent.gameObject.SetActive(!inventorySlotsContainer.parent.gameObject.activeSelf);
        equipmentSlotContainer.parent.gameObject.SetActive(!equipmentSlotContainer.parent.gameObject.activeSelf);
        GameStates.inventoryOpen = inventorySlotsContainer.parent.gameObject.activeSelf;
    }

    private void SetSlotsState(Transform slotsContainer, int size)
    {
        for (int i = 0; i < slotsContainer.childCount; i++)
        {
            slotsContainer.GetChild(i).gameObject.SetActive(i < size);
            SetSlotIndex(slotsContainer, i);
        }
    }

    private void SetSlotIndex(Transform parent,int slotIndex)
    {
        ISlot slot = parent.GetChild(slotIndex).gameObject.GetComponent<ISlot>();

        slot.SetIndex(slotIndex);
    }
}
