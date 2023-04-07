using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol_AI : MonoBehaviour
{
    GameObject player;

    NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer, playerLayer;

    //patrol
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float walkRange;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if(!walkpointSet) SearchForDest();
        if(walkpointSet) agent.SetDestination(destPoint);
        if(Vector3.Distance(transform.position, destPoint) < 5) walkpointSet=false;
    }

    void SearchForDest()
    {
        float z = Random.Range(-walkRange,walkRange);
        float x = Random.Range(-walkRange,walkRange);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if(Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }
}
