using UnityEngine;

public class CharacterAnimationController : MonoBehaviour, ICharacterAnimator
{
    [SerializeField] private Animator animator;

    public void Crouching(bool state)
    {
        animator.SetBool("Crouching", state);
    }

    public void ToBattleMode(bool state)
    {
        animator.SetBool("BattleMode", state);
    }

    public void Walk(float value)
    {
        animator.SetFloat("Move", value);
    }
}
