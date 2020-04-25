using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDelegate : MonoBehaviour
{
    public void Start() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventManager.current.DOOR_OPEN_EVENT();
    }
}
