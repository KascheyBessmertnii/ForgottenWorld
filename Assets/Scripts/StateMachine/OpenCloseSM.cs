using UnityEngine;

[RequireComponent(typeof(Animator))]
public class OpenCloseSM : MonoBehaviour
{
    [SerializeField] private bool isLocked = false;
    [SerializeField] private int keyId;

    private Animator animator;
    public Animator Anim => animator;
    public bool IsLocked => isLocked;
    public int KeyID => keyId;
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
