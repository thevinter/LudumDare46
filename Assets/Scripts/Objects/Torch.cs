using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, IInteractable
{
    public string Name { get => itemName; set => throw new System.NotImplementedException(); }
    [SerializeField]
    private string itemName = "Torch";
    public void Interact(Player p)
    {
        p.torch.Recharge(30);
        Destroy(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
