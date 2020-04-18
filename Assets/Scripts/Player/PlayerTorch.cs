using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorch : MonoBehaviour
{
    public int totalFlame = 100;
    private float currentFlame;
    public float decayRate = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        this.currentFlame = totalFlame;
        InvokeRepeating("Decay", 1f, 1f);
    }
    
    public void Recharge(int x)
    {
        this.currentFlame += x;
    }

    // Update is called once per frame
    void Decay()
    {
        this.currentFlame -= decayRate;
    }
}
