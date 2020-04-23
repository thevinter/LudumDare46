using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public RoomManager roomManager;

    private void Start()
    {
        roomManager = this.GetComponentInParent<RoomManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !roomManager.isSpawned && !roomManager.isStarting)
        {
            roomManager.Spawn();
        }
    }
}
