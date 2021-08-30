public class GameEvents
{
    public delegate void ShowItemInformationMessage(string message);
    public static ShowItemInformationMessage OnShowItemInfo;

    public delegate bool GetItem(GameItem item);
    public static GetItem OnGetItem;

    public delegate void UpdateSlotImage();
    public static UpdateSlotImage OnUpdateSlotImage;

    public delegate void BeginDragItem(SlotUI slot);
    public static BeginDragItem OnBeginDrag;

    public delegate void BeginEndItem(SlotUI slot);
    public static BeginEndItem OnEndDrag;
}
