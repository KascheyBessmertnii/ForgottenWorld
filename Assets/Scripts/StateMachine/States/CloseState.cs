public class CloseState : IAnimationState
{
    public IAnimationState DoState(OpenCloseSM obj)
    {
        if (obj.currentState != this)
        {
            Close(obj);
            return obj.close;
        }

        return obj.open;
    }

    private void Close(OpenCloseSM obj)
    {
        obj.Anim.Play("Close");
    }
}
