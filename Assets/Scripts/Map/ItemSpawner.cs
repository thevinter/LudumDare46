using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour, ISpawner
{
    public GameObject[] items;

    public RoomManager Room { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Decrement()
    {
        throw new System.NotImplementedException();
    }

    public void Increment()
    {
        throw new System.NotImplementedException();
    }

    public void Spawn()
    {
        //print("Spawned!");
        Instantiate(items[Random.Range(0, items.Length - 1)], transform.position, Quaternion.identity);
    }
}
