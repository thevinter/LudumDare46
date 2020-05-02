using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/Cohesion")]
public class CohesionBehaviour : FilteredFlockBehaviour
{
    public override Vector2 calculateMove(FlockAgent agent, List<Transform> context, Flock flock) {
        List<Transform> filteredObjects = (filter == null) ? null : filter.Filter(agent, context);
        if (context.Count == 0 || filteredObjects.Count == 0 || filteredObjects == null) return Vector2.zero;

        Vector2 cohesionMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filteredObjects;
        foreach (Transform item in filteredContext) {
            cohesionMove += (Vector2)item.position;
        }
        cohesionMove /= filteredContext.Count;

        cohesionMove -= (Vector2)agent.transform.position;
        return cohesionMove;
    }
}
