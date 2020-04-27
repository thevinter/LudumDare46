using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    [HideInInspector]
    public  float shootVertical, shootHorizontal;
    public float dashSpeed = 3;
    public float dashTime = 2;
    Player player;
    private Controller2D c;
    private bool isDashing = false;

    void Start()
    {
        player = GetComponent<Player>();
        c = GetComponent<Controller2D>();
    }

    async void Update()
    {
        Vector3 directionalInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        player.SetDirectionalInput(directionalInput);
        if (Input.GetKeyDown(KeyCode.E)) {
            player.Interact();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isDashing) {
            isDashing = true;
            c.Dash(directionalInput);
            isDashing = await Dash();
        }

        shootHorizontal = Input.GetAxisRaw("ShootHorizontal");
        shootVertical = Input.GetAxisRaw("ShootVertical");
        if((shootHorizontal != 0 || shootVertical != 0))
        {
            player.Shoot(shootHorizontal, shootVertical);
        }
    }

    async Task<bool> Dash()
    {
        await Task.Delay(1000);
        return false;
    }
}