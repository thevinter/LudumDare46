﻿using ChrisTutorials.Persistent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour, IInteractable
{
    public AudioClip pickupSound;
    public string Name { get => itemName; set => throw new System.NotImplementedException(); }
    [SerializeField]
    private string itemName = "Torch";
    public void Interact(Player p)
    {
        AudioManager.Instance.Play(pickupSound, transform, .05f);
        p.RechargeHealth(20);
        Destroy(this.gameObject.GetComponent<SpriteRenderer>());
        Destroy(this.gameObject.GetComponent<Collider2D>());
        Destroy(this.gameObject, 1f);
    }
}
