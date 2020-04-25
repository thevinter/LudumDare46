using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;
    
    public void Awake() {
        current = this;
    }

    public event Action OnDoorOpen;
    public void DOOR_OPEN_EVENT() {
        OnDoorOpen?.Invoke();
    }
}
