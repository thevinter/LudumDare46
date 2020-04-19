using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISpawnable
{
    RoomManager Room { get; set; }
    void Decrement();
    void Increment();
}
