using UnityEngine;

public class CharacterAnimationController : MonoBehaviour, IAnimator
{
    [SerializeField] private Animator animator;
    [Header("Animations names")]
    [SerializeField] private string idle = "IDLE";
    [SerializeField] private string walk = "Walk";

    public void PlayIDLE()
    {
        animator.Play(idle);
    }

    public void PlayWalk()
    {
        animator.Play(walk);
    }
}
