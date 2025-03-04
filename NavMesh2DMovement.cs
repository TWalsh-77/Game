using UnityEngine;
using UnityEngine.AI;

public class NavMesh2DMovement : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Ensure proper 2D movement
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // Snap to NavMesh
        PlaceOnNavMesh();
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    void PlaceOnNavMesh()
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position, out hit, 5f, NavMesh.AllAreas))
        {
            transform.position = hit.position;  // Move to nearest NavMesh position
        }
        else
        {
            Debug.LogError("No valid NavMesh found near the enemy! Check if NavMesh is baked.");
        }
    }
}