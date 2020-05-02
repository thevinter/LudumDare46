using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/TargetFollow")]
public class TargetBehaviour : FilteredFlockBehaviour {

    private Transform target;
    public override Vector2 calculateMove(FlockAgent agent, List<Transform> context, Flock flock) {
        target = flock.target;
        Vector2 avoidanceMove = target.position - agent.transform.position;
        
        return avoidanceMove;
    }
}
