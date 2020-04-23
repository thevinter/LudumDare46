using ChrisTutorials.Persistent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour, IInteractable
{
    public string Name { get => itemName; set => throw new System.NotImplementedException(); }
    public GameObject weapon;
    public string itemName = "Magical Bullet";
    public AudioClip pickUp;
    public void Interact(Player p)
    {
        p.AddWeapon(weapon);
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<Collider2D>());
        Destroy(this.gameObject, 1f);
        AudioManager.Instance.Play(pickUp, transform, .05f);
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
