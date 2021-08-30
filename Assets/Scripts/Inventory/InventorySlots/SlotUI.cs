using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour, ISlot, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] protected Image slotImage = default;

    protected int index = -1;
    protected Sprite defaultSprite = null;
    protected PlayerInventoryController inventory;

    public int Index => index;
    public Sprite Icon => slotImage.sprite;

    private void OnEnable()
    {
        GameEvents.OnUpdateSlotImage += UpdateIcon;
        UpdateIcon();
    }

    private void OnDisable()
    {
        GameEvents.OnUpdateSlotImage -= UpdateIcon;
    }

    private void Start()
    {
        defaultSprite = slotImage.sprite;
        inventory = PlayerInventoryController.Instance;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        //If slots not empty show item info
        ItemSO item = inventory.GetSlotItem(this) ;

        ShowInfoEvent(item == null ? "" : item.GetItemInfo());
    }

    public virtual void SetIndex(int index)
    {
        this.index = index;
    }

    public virtual EquipmentType GetSlotType()
    {
        return EquipmentType.None;
    }

    /// <summary>
    /// Update slot item icon
    /// </summary>
    /// <param name="icon">if icon is null will be set default slot image</param>
    public void ShowIcon(Sprite icon)
    {
        slotImage.sprite = icon ?? defaultSprite;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GameEvents.OnBeginDrag?.Invoke(this);
        ShowIcon(null);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerEnter == null)
        {
            EndDragEvent(null); //If drop not in inventory slot set insdex as -1      
        }
        else
        {
            var obj = eventData.pointerEnter.transform.GetComponent<SlotUI>(); //Check object under cursor
            EndDragEvent(obj ?? this); //If its slot, move to slot else return item to current slot
        }

        UpdateIcon();
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    protected virtual void UpdateIcon()
    {
        if (index < 0) return;
        ItemSO item = inventory.GetSlotItem(this);
        ShowIcon(item?.icon);
    }
    protected void EndDragEvent(SlotUI slot)
    {
        GameEvents.OnEndDrag?.Invoke(slot);
    }
    protected void ShowInfoEvent(string text)
    {
        GameEvents.OnShowItemInfo?.Invoke(text);
    }
}
