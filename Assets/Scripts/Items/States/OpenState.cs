public class OpenState : IAnimationState
{
    public IAnimationState DoState(OpenCloseBaseClass obj)
    {
        if (obj.currentState != this)
        {
            Open(obj);
            return obj.open;
        }

        return obj.close;
    }

    private void Open(OpenCloseBaseClass obj)
    {
        obj.Anim.Play("Open");
    }
}
