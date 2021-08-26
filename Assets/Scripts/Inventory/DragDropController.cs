using UnityEngine;
using UnityEngine.UI;

public class DragDropController : MonoBehaviour, IBeginDragItem, IEndDragItem
{
    [SerializeField] private Image dragDropImage;

    private Slot startSlot = null;

    private void Start()
    {
        UpdateImage();
    }

    private void OnEnable()
    {
        GameEvents.OnBeginDrag += BeginDrag;
        GameEvents.OnEndDrag += EndDrag;
    }

    private void OnDisable()
    {
        GameEvents.OnBeginDrag -= BeginDrag;
        GameEvents.OnEndDrag -= EndDrag;
    }

    private void Update()
    {
        if (startSlot != null && dragDropImage.gameObject.activeSelf)
            dragDropImage.transform.position = Input.mousePosition;
    }

    private void UpdateImage(Sprite icon = null)
    {
        dragDropImage.sprite = icon;
        dragDropImage.gameObject.SetActive(icon != null);
    }

    public void BeginDrag(Slot slot)
    {
        startSlot = slot;
        UpdateImage(slot.Icon);
    }

    public void EndDrag(Slot slot)
    {
        if (slot == null)
            PlayerInventoryController.Instance.DropItemToGround(startSlot);
        else
        {
            PlayerInventoryController.Instance.ChangeItemPlace(startSlot, slot);
            GameEvents.OnUpdateSlotImage?.Invoke();
        }

        UpdateImage();
    }
}