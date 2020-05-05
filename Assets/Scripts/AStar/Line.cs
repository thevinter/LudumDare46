﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Line
{
    const float verticalLineGradient = 1e5f;

    float gradient;
    float y_intercept;
    Vector2 pointOnLine_1, pointOnLine_2;
    float gradientPerpendicular;

    bool approachSide;

    public Line(Vector2 point, Vector2 pointPerpendicularToLine)
    {
        float dx = point.x - pointPerpendicularToLine.x;
        float dy = point.y - pointPerpendicularToLine.y;

        if (dx == 0) gradientPerpendicular = verticalLineGradient;
        else gradientPerpendicular = dx / dy;

        if(gradientPerpendicular == 0) gradient = verticalLineGradient;
        else gradient = -1 / gradientPerpendicular;

        y_intercept = point.y - gradient * point.x;
        pointOnLine_1 = point;
        pointOnLine_2 = point + new Vector2(1, gradient);
        approachSide = false;
        approachSide = GetSide(pointPerpendicularToLine);
    }

    bool GetSide(Vector2 p)
    {
        return (p.x - pointOnLine_1.x) * (pointOnLine_2.y - pointOnLine_1.y) > (p.y - pointOnLine_1.y) * (pointOnLine_2.x - pointOnLine_1.x);
    }

    public bool HasCrossedLine(Vector2 p)
    {
        return GetSide(p) != approachSide;
    }

    public void DrawWithGizmos(float length)
    {
        Vector2 lineDir = new Vector2(1, gradient).normalized;
        Vector2 lineCenter = new Vector2(pointOnLine_1.x, pointOnLine_1.y);
        Gizmos.DrawLine(lineCenter - lineDir * length / 2, lineCenter + lineDir * length / 2f);
    }
}
