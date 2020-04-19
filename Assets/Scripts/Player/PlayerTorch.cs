using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorch : MonoBehaviour
{
    public int totalFlame = 100;
    private float currentFlame;
    public float decayRate = 0.01f;
    private bool isConsuming = true;
    public Light l;

    private void Update()
    {
        float dampening = currentFlame / 100;
        float desiredRange = Random.Range(13f, 18f);
        l.range = Mathf.Lerp(l.range, desiredRange, .2f) * dampening;
        
    }

  


    // Start is called before the first frame update
    void Start()
    {
        l = GetComponentInChildren<Light>();
        this.currentFlame = totalFlame;
        InvokeRepeating("Decay", 1f, 1f);
    }
    
    public void Recharge(int x)
    {
        this.currentFlame += x;
    }

    public void SetConsuming(bool consume)
    {
        isConsuming = consume;
    }

    public void Fill()
    {
        currentFlame = totalFlame;
    }

    // Update is called once per frame
    void Decay()
    {
        if (isConsuming)
        {
            this.currentFlame -= decayRate;
        }
    }
}
