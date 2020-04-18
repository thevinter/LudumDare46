using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    float moveSpeed = 6;

    Vector3 velocity;

    public bool canInteract = false;
    public PlayerTorch torch;
    public Controller2D controller;
    public PlayerShoot shoot;
    public IInteractable obj;

    Vector2 directionalInput;

    private void Update()
    {
        controller.Move(directionalInput.normalized, moveSpeed);
    }

    void Start()
    {
        controller = GetComponent<Controller2D>();
        shoot = GetComponent<PlayerShoot>();
        torch = GetComponent<PlayerTorch>();
    }

    public void Interact()
    {
        obj.Interact(this);
    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Usable"))
        {
            obj = collision.gameObject.GetComponent<IInteractable>();
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Usable"))
        {
            obj = null;
            canInteract = false;
        }
    }

}
