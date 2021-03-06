﻿using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;


public class PlayerFlame : MonoBehaviour
{
    [SerializeField] private FloatVariable totalFlame;
    [SerializeField] private FloatVariable decayRate;
    [SerializeField] private UnityEvent PlayerDeathEvent;
    [SerializeField] private FloatVariable currentRange;
    [SerializeField] private FloatVariable currentFlame;
    private bool isBeingConsumed = true;

    private int nframes = 0;
    private float desiredIntensity = 2;
    private float desiredRange = 15;

    private Player p;
    [SerializeField] private Light2D l;

    private void Update() {
        currentRange.SetValue(l.pointLightOuterRadius);
            nframes++;
            if (nframes >= 10) {
                desiredRange = Random.Range(2.48f, 2.52f);
                desiredIntensity = Random.Range(1.7f, 2.2f);
                nframes = 0;
            }

            if (p.tutorial) l.pointLightInnerRadius = desiredRange;
            if (!p.tutorial) l.intensity = desiredIntensity;

            if (currentFlame.Value > totalFlame.Value) currentFlame.SetValue(totalFlame.Value);
            if (currentFlame.Value < 0) PlayerDeathEvent.Invoke();
    }

    void Start() {
        GetComponents();
        this.currentFlame.SetValue(totalFlame.Value);
        InvokeRepeating("Decay", 1f, 1f);
    }
    
    public void Recharge(int x) {
        this.currentFlame.ApplyChange(x);
    }

    public void SetConsuming(bool state) {
        isBeingConsumed = state;
    }

    public void Fill() {
        currentFlame.SetValue(totalFlame.Value);
    }

    void Decay() {
        if (isBeingConsumed) {
            this.currentFlame.ApplyChange(-decayRate.Value);
        }
    }

    private void GetComponents() {
        p = GetComponent<Player>();
        l = GetComponentInChildren<Light2D>();
    }

    public float GetCurrentFlame() {
        return currentFlame.Value;
    }

    public void ReduceCurrentFlame(int value) {
        currentFlame.ApplyChange(value);
    }
}
