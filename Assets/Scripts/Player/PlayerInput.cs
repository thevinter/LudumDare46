using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    public float shootHorizontal;
    public float shootVertical;
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        Vector3 directionalInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        player.SetDirectionalInput(directionalInput);

        if (player.canInteract && Input.GetKeyDown(KeyCode.E))
        {
            player.Interact();
        }

        shootHorizontal = Input.GetAxisRaw("ShootHorizontal");
        shootVertical = Input.GetAxisRaw("ShootVertical");
        if((shootHorizontal != 0 || shootVertical != 0))
        {
            player.shoot.Shoot(shootHorizontal, shootVertical);
        }
    }
}