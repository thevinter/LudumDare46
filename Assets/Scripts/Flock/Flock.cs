using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehaviour behaviour;

    [Range(1, 500)]
    public int startingCount = 5;
    const float agentDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighbourRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighbourRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    public float chaseRadius;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for(int i = 0; i < startingCount; i++) {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                (Random.insideUnitCircle * startingCount * agentDensity) + (Vector2)transform.position,
                Quaternion.Euler(Vector3.forward * Random.Range(0, 360)),
                transform
                );
            newAgent.name = "Agent " + i;
            newAgent.Initialize(this);
            agents.Add(newAgent);
        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach (FlockAgent agent in agents) {
            if (Vector2.Distance(agent.transform.position, target.transform.position) < chaseRadius) {
                List<Transform> context = GetNearbyObjects(agent);
                Vector2 move = behaviour.calculateMove(agent, context, this);
                move *= driveFactor;
                if (move.sqrMagnitude > squareMaxSpeed) {
                    move = move.normalized * maxSpeed;
                }
                agent.Move(move);
            }
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent agent) {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighbourRadius);
        foreach(Collider2D c in contextColliders) {
            if(c != agent.AgentCollider) {
                context.Add(c.transform);
            }
        }
        return context;
    }
}
