using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    [HideInInspector]
    public  float shootVertical, shootHorizontal;
    public float dashSpeed = 3;
    public float dashTime = 2;
    private float dashTimeEnd;
    Player player;
    private Controller2D c;
    private bool isDashing = false;

    void Start()
    {
        dashTimeEnd = dashTime;
        player = GetComponent<Player>();
        c = GetComponent<Controller2D>();
    }

    void Update()
    {

        

        Vector3 directionalInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        player.SetDirectionalInput(directionalInput);
        if (player.canInteract && Input.GetKeyDown(KeyCode.E))
        {
            player.Interact();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            c.Dash(directionalInput);

            StartCoroutine(Dash());

        }


        IEnumerator Dash()
        {
            yield return new WaitForSeconds(dashTime);
            isDashing = false;
        }

        shootHorizontal = Input.GetAxisRaw("ShootHorizontal");
        shootVertical = Input.GetAxisRaw("ShootVertical");
        if((shootHorizontal != 0 || shootVertical != 0))
        {
            player.shoot.Shoot(shootHorizontal, shootVertical);
        }
    }
}