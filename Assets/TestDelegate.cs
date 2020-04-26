using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestDelegate : MonoBehaviour
{
    public UnityEvent OpenDoorEvent;
    private void OnTriggerEnter2D(Collider2D collision) {
        OpenDoorEvent.Invoke();
    }
}
