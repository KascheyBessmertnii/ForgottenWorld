using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, ISlot, IPointerClickHandler
{
    [SerializeField] private Image slotImage;

    private int index = -1;
    private Sprite defaultSprite = null;
    private PlayerInventoryController inventory;

    public int Index => index;

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
        GameEvents.OnShowItemInfo?.Invoke("Click to slot with index " + index);
    }

    public void SetIndex(int index)
    {
        this.index = index;
    }

    public void ShowIcon(Sprite icon)
    {
        if (icon != null)
        {
            slotImage.sprite = icon;
        }
        else
        {
            slotImage.sprite = defaultSprite;
        }
    }

    private void UpdateIcon()
    {
        if (index >= 0)
            ShowIcon(inventory.GetItemSprite(index));
    }
}
