using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TempTeleport : MonoBehaviour
{
    public Vector2 destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) collision.gameObject.transform.position = destination;
    }

    void OnDrawGizmos()
    {
        if (destination != null)
        {
            Gizmos.color = Color.red;
            float size = .3f;


            Vector2 globalWaypointPos = destination;
            Gizmos.DrawLine(globalWaypointPos - Vector2.up * size, globalWaypointPos + Vector2.up * size);
            Gizmos.DrawLine(globalWaypointPos - Vector2.left * size, globalWaypointPos + Vector2.left * size);

        }
    }
}
