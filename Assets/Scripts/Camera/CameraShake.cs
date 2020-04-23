using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Camera c;
    public float shake = 0;
    float shakeAmount = 0.1f;
    float decreaseFactor = 1.8f;

    // Start is called before the first frame update
    void Start()
    {
        c = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(shake > 0)
        {
            transform.localPosition = Random.insideUnitCircle * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0;
        }
    }
}
