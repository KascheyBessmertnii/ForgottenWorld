using UnityEngine;

public interface IBeginDragItem
{
    void BeginDrag(SlotUI slot);
}

public interface IEndDragItem
{
    void EndDrag(SlotUI slot);
}