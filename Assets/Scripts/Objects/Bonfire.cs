using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour, IInteractable
{
    public string Name { get => objectName; set => throw new System.NotImplementedException(); }
    [SerializeField]
    private string objectName = "Bonfire";
    private bool isSitting = false;
    public void Interact(Player p)
    {
        p.torch.SetConsuming(isSitting);
        p.SetRestState(!isSitting);
        isSitting = !isSitting;
    }
}
