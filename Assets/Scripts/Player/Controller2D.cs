using UnityEngine;
using System.Collections;

public class Controller2D : MonoBehaviour
{
    [HideInInspector]
    private Rigidbody2D rb;
    public LayerMask mask;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    public void Move(Vector2 moveAmount)
    {
        Move(moveAmount);
    }


    /// <summary>
    /// Moves the character based on the input
    /// </summary>
    /// <param name="moveAmount">The direction of the movement</param>
    /// <param name="speed">The speed of the movement</param>
    public void Move(Vector3 moveAmount, float speed)
    {
        rb.MovePosition(
            transform.position + moveAmount * speed * Time.deltaTime
        );
    }

    private Vector3 CanMove(Vector3 dir, float dist)
    {
        Vector3 actualMove = dir;
        Debug.DrawRay(transform.position, dir);
        float actualDist = Physics2D.Raycast(transform.position, dir, dist, mask).distance;
        if (Physics2D.Raycast(transform.position, dir, dist, mask) && actualDist < dist)
        {
            print(Physics2D.Raycast(transform.position, dir, dist) );
            actualMove *= actualDist;
            return actualMove;
        }
        else
        {
            return dir * dist;
        }

    }

    public void Dash(Vector3 moveAmount) {
        float dashDistance = 1f;
        Vector3 dist = CanMove(moveAmount, dashDistance);
        transform.position += dist;
    }
}