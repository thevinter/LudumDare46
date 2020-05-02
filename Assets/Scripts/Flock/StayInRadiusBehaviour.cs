﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/StayInRadius")]
public class StayInRadiusBehaviour : FlockBehaviour
{
    public Vector2 center;
    public float radius = 15;

    public override Vector2 calculateMove(FlockAgent agent, List<Transform> context, Flock flock) {
        Vector2 centerOffset =center - (Vector2)agent.transform.position;
        float t = centerOffset.magnitude / radius;
        if (t < 0.9f) {
            return Vector2.zero; 
        }
        return centerOffset * t * t;
    }
}
