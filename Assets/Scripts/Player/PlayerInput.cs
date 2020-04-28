using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    [HideInInspector]
    public float shootVertical, shootHorizontal;


    private Player player;
    private Controller2D c;


    void Start()
    {
        player = GetComponent<Player>();
        c = GetComponent<Controller2D>();
    }

    void Update()
    {
        Vector3 directionalInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        player.SetDirectionalInput(directionalInput);
        if (Input.GetKeyDown(KeyCode.E)) {
            player.Interact();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            c.Dash(directionalInput);

        }

        shootHorizontal = Input.GetAxisRaw("ShootHorizontal");
        shootVertical = Input.GetAxisRaw("ShootVertical");
        if((shootHorizontal != 0 || shootVertical != 0))
        {
            player.Shoot(shootHorizontal, shootVertical);
        }
    }
}