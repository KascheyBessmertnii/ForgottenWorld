using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TDCharacterMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private IAnimator animator;

    private void LateUpdate()
    {
        if(agent.remainingDistance < agent.stoppingDistance)
        {
            animator.PlayIDLE();
        }
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
        animator.PlayWalk();
    }
}