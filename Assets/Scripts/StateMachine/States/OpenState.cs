public class OpenState : IAnimationState
{
    public IAnimationState DoState(OpenCloseSM obj)
    {
        if (obj.currentState != this && !obj.IsLocked)
        {
            Open(obj);
            return obj.open;
        }

        return obj.close;
    }

    private void Open(OpenCloseSM obj)
    {
        obj.Anim.Play("Open");
    }
}
