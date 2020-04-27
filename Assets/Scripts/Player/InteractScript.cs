using UnityEngine;
using UnityEngine.Events;

public class InteractScript : MonoBehaviour
{
    public UnityEvent enterInteractable;
    public UnityEvent exitInteractable;
    private IInteractable obj = null;
    private bool canInteract = false;

    [SerializeField] private StringVariable itemText;

    public void Interact(Player p)
    {
        if (canInteract) obj.Interact(p);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<IInteractable>() != null) {
            obj = collision.gameObject.GetComponent<IInteractable>();
            itemText.SetValue(obj.Name);
            enterInteractable.Invoke();
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<IInteractable>() != null) {
            exitInteractable.Invoke();
            itemText.SetValue("");
            obj = null;
            canInteract = false;
        }
    }
}
