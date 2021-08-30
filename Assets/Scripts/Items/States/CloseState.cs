public class CloseState : IAnimationState
{
    public IAnimationState DoState(OpenCloseBaseClass obj)
    {
        if (obj.currentState != obj.close)
        {
            Close(obj);
            return obj.close;
        }

        return obj.open;
    }

    private void Close(OpenCloseBaseClass obj)
    {
        obj.Anim.Play("Close");
    }
}
