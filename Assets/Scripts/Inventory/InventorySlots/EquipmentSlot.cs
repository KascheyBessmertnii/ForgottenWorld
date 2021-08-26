using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : Slot
{
    [SerializeField] private EquipmentType type;
    [SerializeField] private int slotIndex;

    public override void OnPointerClick(PointerEventData eventData)
    {
        GameEvents.OnShowItemInfo?.Invoke("Click to " + type + " slot");
    }


    public override EquipmentType GetSlotType()
    {
        return type;
    }
    protected override void UpdateIcon()
    {
        if (index < 0) return;
        ItemSO item = inventory.GetEquipSlotItem(index);
        ShowIcon(item == null ? null : item.icon);
    }
}
