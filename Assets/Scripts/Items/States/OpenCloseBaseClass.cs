using UnityEngine;

[RequireComponent(typeof(Animator))]
public class OpenCloseBaseClass : MonoBehaviour
{
    private Animator animator;
    public Animator Anim => animator;
    public OpenState open { get; private set; } = new OpenState();
    public CloseState close { get; private set; } = new CloseState();

    public IAnimationState currentState { get; private set; }

    private void OnEnable()
    {
        currentState = close;
        TryGetComponent(out animator);
    }

    public void SetState(IAnimationState state)
    {
        currentState = state.DoState(this);
    }
}
