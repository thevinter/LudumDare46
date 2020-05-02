using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/Obstacle Avoidance")]
public class ObstacleAvoidanceBehaviour : FilteredFlockBehaviour {
    public override Vector2 calculateMove(FlockAgent agent, List<Transform> context, Flock flock) {
        List<Transform> filteredObjects = (filter == null) ? null : filter.Filter(agent, context);
        if (context.Count == 0 || filteredObjects.Count == 0 || filteredObjects == null) return Vector2.zero;

        Vector2 avoidanceMove = Vector2.zero;
        int navoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filteredObjects;
        foreach (Transform item in filteredContext) {
            Vector3 closestPoint = item.gameObject.GetComponent<Collider2D>().ClosestPoint(agent.transform.position);
            if (Vector2.SqrMagnitude(closestPoint - agent.transform.position) < flock.SquareAvoidanceRadius) {
                navoid++;
                avoidanceMove += (Vector2)(agent.transform.position - item.position);
            }
        }
        if (navoid != 0) avoidanceMove /= navoid;
        return avoidanceMove;
    }
}
