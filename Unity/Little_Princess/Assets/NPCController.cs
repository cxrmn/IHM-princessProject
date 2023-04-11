using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour {
    public float speed = 3f;

    NavMeshAgent agent;

    Vector3 currentDirection;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        SetRandomDirection();
    }

    void Update() {
        if (agent.remainingDistance < 0.1f) {
            SetRandomDirection();
        }
        agent.Move(currentDirection * Time.deltaTime);
    }

    void SetRandomDirection() {
        Vector2 randomDirection2D = Random.insideUnitCircle.normalized * 10f;
        Vector3 randomDirection = new Vector3(randomDirection2D.x, 0f, randomDirection2D.y);
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas);
        currentDirection = (hit.position - transform.position).normalized;
    }
}
