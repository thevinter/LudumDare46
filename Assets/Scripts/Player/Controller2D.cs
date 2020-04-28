using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class Controller2D : MonoBehaviour
{
    [Tooltip("The mask used for determining the dash walls")]
    public LayerMask dashMask;

    private Rigidbody2D rb;
    private bool isDashing;

    [Tooltip("The distance covered by the dash")]
    public float dashDistance = 3;
    [Tooltip("The time in ms between a dash")]
    public int dashTime = 1000;

    public void Start(){
        rb = GetComponent<Rigidbody2D>(); 
    }

    /// <summary>
    /// Moves the character based on an input
    /// </summary>
    /// <param name="moveAmount">The direction of the movement</param>
    public void Move(Vector2 moveAmount){
        Move(moveAmount);
    }


    /// <summary>
    /// Moves the character based on an input and a speed
    /// </summary>
    /// <param name="moveAmount">The direction of the movement</param>
    /// <param name="speed">The speed of the movement</param>
    public void Move(Vector3 moveAmount, float speed){
        rb.MovePosition(
            transform.position + moveAmount * speed * Time.deltaTime
        );
    }

    /// <summary>
    /// Returns true if the player can move in a direction for a given distance without hitting a collider
    /// </summary>
    /// <param name="dir">The normalized direction of the movement</param>
    /// <param name="dist">The distance of the movement</param>
    /// <returns></returns>
    private Vector3 CanMove(Vector3 dir, float dist){
        Vector3 actualMove = dir;
        Debug.DrawRay(transform.position, dir);
        float actualDist = Physics2D.Raycast(transform.position, dir, dist, dashMask).distance;
        if (Physics2D.Raycast(transform.position, dir, dist, dashMask) && actualDist < dist){
            print(Physics2D.Raycast(transform.position, dir, dist) );
            actualMove *= actualDist;
            return actualMove;
        } else return dir * dist;
    }

    /// <summary>
    /// Translates the player in a direction simulating a dash
    /// </summary>
    /// <param name="moveAmount">The amount of movement</param>
    public async void Dash(Vector3 moveAmount) {
        if (!isDashing) {
            isDashing = true;
            Vector3 dist = CanMove(moveAmount, dashDistance);
            transform.position += dist;
            await Task.Delay(dashTime);
            isDashing = false;
        }
    }
}