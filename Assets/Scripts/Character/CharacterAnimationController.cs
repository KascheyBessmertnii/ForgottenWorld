using UnityEngine;

public class CharacterAnimationController : MonoBehaviour, IAnimator
{
    [SerializeField] private Animator animator;

    public void Walk(float value)
    {
        animator.SetFloat("Move", value);
    }
}
