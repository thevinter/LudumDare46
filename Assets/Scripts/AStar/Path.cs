using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path
{

    public readonly Vector2[] lookPoints;
    public readonly Line[] turnBoundaries;
    public readonly int finishLineIndex;

    public Path(Vector2[] waypoints, Vector2 startPos, float turnDst)
    {
        lookPoints = waypoints;
        turnBoundaries = new Line[lookPoints.Length];
        finishLineIndex = turnBoundaries.Length - 1;

        Vector2 previousPoint = startPos;
        for (int i = 0; i < lookPoints.Length; i++)
        {
            Vector2 currentPoint = (lookPoints[i]);
            Vector2 dirToCurrentPoint = (currentPoint - previousPoint).normalized;
            Vector2 turnBoundaryPoint = (i == finishLineIndex) ? currentPoint :  previousPoint;
            turnBoundaries[i] = new Line(currentPoint, previousPoint - dirToCurrentPoint * turnDst);
            previousPoint = turnBoundaryPoint;
        }
    }

    public void DrawWithGizmos()
    {

        Gizmos.color = Color.black;
        foreach (Vector2 p in lookPoints)
        {
            Gizmos.DrawCube(p + Vector2.up, Vector2.one);
        }

        Gizmos.color = Color.white;
        foreach (Line l in turnBoundaries)
        {
            l.DrawWithGizmos(1);
        }

    }

}