using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filters/Physics Layer")]

public class PhysicsLayerFilter : ContextFilter
{
    public LayerMask mask;
    public override List<Transform> Filter(FlockAgent agent, List<Transform> original) {
        List<Transform> filter = new List<Transform>();
        foreach (Transform item in original) {

            if (mask == (mask | (1 << item.gameObject.layer))){
                filter.Add(item);
            }
        }
        return filter;
    }
}
