using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour, ISpawner
{
    public GameObject[] barrier;
    public void Spawn()
    {
        GameObject itemToSpawn = barrier[Random.Range(0, barrier.Length - 1)];
        if (itemToSpawn != null)
            Instantiate(itemToSpawn, transform.position, Quaternion.identity);
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
