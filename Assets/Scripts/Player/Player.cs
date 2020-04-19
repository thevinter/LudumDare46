using UnityEngine;
using System.Collections;
using TMPro;

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
    public bool isResting = false;

    private PlayerAnimator anim; 

    public GameObject itemTextBox;

    Vector2 directionalInput;

    private void Update()
    {
        if(!isResting)
            controller.Move(directionalInput.normalized, moveSpeed);
    }

    public void SetRestState(bool rest)
    {
        isResting = rest;
        //fai robe animazione e musica
        if (isResting)
        {
            torch.Fill();
        }
    }

    void Start()
    {
        anim = GetComponent<PlayerAnimator>();
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
            print("pene");
            obj = collision.gameObject.GetComponent<IInteractable>();
            itemTextBox.GetComponent<TextMeshProUGUI>().text = obj.Name;
            itemTextBox.SetActive(true);
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Usable"))
        {
            itemTextBox.SetActive(false);
            obj = null;
            canInteract = false;
        }
    }

}
