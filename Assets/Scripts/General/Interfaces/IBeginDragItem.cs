using UnityEngine;

public interface IBeginDragItem
{
    void BeginDrag(Slot slot);
}

public interface IEndDragItem
{
    void EndDrag(Slot slot);
}