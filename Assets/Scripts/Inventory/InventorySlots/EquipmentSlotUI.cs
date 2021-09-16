using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlotUI : SlotUI
{
    [SerializeField] private EquipmentType type;

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
