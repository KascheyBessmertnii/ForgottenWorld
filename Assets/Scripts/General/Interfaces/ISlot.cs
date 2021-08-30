public interface ISlot : IShowIcon, IHaveType
{
    int Index { get;}

    void SetIndex(int index);
}
