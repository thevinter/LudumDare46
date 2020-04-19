using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoomUtils;

public class RoomTemplates : MonoBehaviour
{

    public OpeningType?[,] map = new OpeningType?[100,100];
    map[MapProps.center, MapProps.center] = OpeningType.all;

    public GameObject[] rooms;
    public GameObject closedRoom;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
