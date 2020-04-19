using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour, ISpawner
{
    public GameObject[] barrier;
    public void Spawn()
    {
        Instantiate(barrier[Random.Range(0, barrier.Length - 1)], transform.position, Quaternion.identity);
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
