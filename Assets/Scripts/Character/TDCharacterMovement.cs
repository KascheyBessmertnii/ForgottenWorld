using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TDCharacterMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    protected ICharacterAnimator animator;

    private void LateUpdate()
    {
        animator.Walk(agent.velocity.magnitude);
    }

    void Start()
    {
        TryGetComponent(out agent);
        TryGetComponent(out animator);
    }

    protected void MoveTo(Vector3 position, float speed)
    {
        agent.speed = speed;
        agent.SetDestination(position);    
    }
}
