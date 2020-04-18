using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoomType = System.Int32;

public class RoomTemplates : MonoBehaviour
{
    public const int EMPTY = 0;
    public const int TOP = 1;
    public const int RIGHT = 2;
    public const int BOTTOM = 4;
    public const int LEFT = 8;

    public RoomType[,] map = new int[100,100];

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;
    public GameObject closedRoom;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
