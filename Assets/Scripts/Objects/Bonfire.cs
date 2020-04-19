using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour, IInteractable
{
    public string Name { get => objectName; set => throw new System.NotImplementedException(); }
    [SerializeField]
    private string objectName = "Bonfire";
    private bool isSitting = false;
    public Light l;

    private void Start()
    {
        l = GetComponentInChildren<Light>();
    }
    public void Interact(Player p)
    {
        p.torch.SetConsuming(isSitting);
        p.SetRestState(!isSitting);
        isSitting = !isSitting;
    }

    void Update()
    {
        float desiredRange = Random.Range(8f, 12f);
        l.range = Mathf.Lerp(l.range, desiredRange, .2f);
    }
}
