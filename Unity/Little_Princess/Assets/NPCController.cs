using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour {
    public Transform destination;

    NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void Update() {
        if (agent.remainingDistance < 0.1f) {
            SetRandomDestination();
        }
    }

    void SetRandomDestination() {
        Vector3 randomDirection = Random.insideUnitSphere * 10f;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas);
        destination.position = hit.position;
        agent.SetDestination(destination.position);
    }
}
