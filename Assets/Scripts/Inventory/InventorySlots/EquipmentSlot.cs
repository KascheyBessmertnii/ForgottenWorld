using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : Slot
{
    [SerializeField] private EquipmentType type;

    public override void OnPointerClick(PointerEventData eventData)
    {
        GameEvents.OnShowItemInfo?.Invoke("Click to " + type + " slot");
    }
}
