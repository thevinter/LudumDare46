using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filters/Same Flock")]

public class SameFlockFilter : ContextFilter {
    public override List<Transform> Filter(FlockAgent agent, List<Transform> original) {
        List<Transform> filter = new List<Transform>();
        foreach(Transform item in original) {
            FlockAgent itemAgent = item.GetComponent<FlockAgent>();
            if (itemAgent != null && itemAgent.AgentFlock == agent.AgentFlock) filter.Add(item);
        }
        return filter;
    }
}
