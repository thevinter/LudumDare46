using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoomUtils;

public class RoomTemplates : MonoBehaviour
{

    public OpeningType?[,] map = new OpeningType?[100,100];

    public GameObject[] rooms;
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
