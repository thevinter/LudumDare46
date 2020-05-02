using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignement")]

public class AlignementBehaviour : FilteredFlockBehaviour
{
    public override Vector2 calculateMove(FlockAgent agent, List<Transform> context, Flock flock) {
        List<Transform> filteredObjects = (filter == null) ? null : filter.Filter(agent, context);
        if (context.Count == 0 || filteredObjects.Count == 0 || filteredObjects == null) return agent.transform.up;

        Vector2 alignementMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filteredObjects;
        foreach (Transform item in filteredContext) {
            alignementMove += (Vector2)item.transform.up;
        }
        alignementMove /= context.Count;
        return alignementMove;
    }
}
