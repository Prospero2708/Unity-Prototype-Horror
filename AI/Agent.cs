using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;

    private void Start()
    {
        agent.isStopped = true;

        if (Target != null)
        {
            agent.SetDestination(Target.position);
        }
    }

    private void Update()
    {
        if (agent.pathPending) return;

        if (agent.remainingDistance > 2f)
        {
            if (agent.isStopped)
            {
                agent.isStopped = false;
                anim.SetFloat("E_speed", 1.5f);
            }
        }
        else
        {
            if (!agent.isStopped)
            {
                agent.isStopped = true;
                anim.SetFloat("E_speed", 0f);
                agent.ResetPath();
            }
        }
    }

}
