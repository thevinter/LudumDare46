using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/SteeredCohesion")]
public class SteeredCohesionBehaviour : FilteredFlockBehaviour {
    Vector2 currentVelocity;
    public float agentSmoothTime = 0.5f;
    
    public override Vector2 calculateMove(FlockAgent agent, List<Transform> context, Flock flock) {
        List<Transform> filteredObjects = (filter == null) ? null : filter.Filter(agent, context);
        if (context.Count == 0 || filteredObjects.Count == 0 || filteredObjects == null) return Vector2.up;

        Vector2 cohesionMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filteredObjects;
        foreach (Transform item in filteredContext) {
            cohesionMove += (Vector2)item.position;
        }
        cohesionMove /= filteredContext.Count;

        cohesionMove -= (Vector2)agent.transform.position;
        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);
        return cohesionMove;
    }
}
