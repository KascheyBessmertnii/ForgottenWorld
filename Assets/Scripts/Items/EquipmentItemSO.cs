using UnityEngine;

[CreateAssetMenu(menuName = "My game/Items/Equipment item")]
public class EquipmentItemSO : ItemSO
{
    public EquipmentType equipSlot;

    public override EquipmentType EquipmentSlot()
    {
        return equipSlot;
    }
}
