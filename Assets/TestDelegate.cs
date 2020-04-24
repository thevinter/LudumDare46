using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDelegate : MonoBehaviour
{
    public delegate void DoorDelegate();
    public DoorDelegate doorOpen; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("door opened");
        if(doorOpen != null) doorOpen();
    }
}
