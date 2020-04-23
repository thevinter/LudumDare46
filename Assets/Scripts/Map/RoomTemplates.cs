using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoomUtils;

public class RoomTemplates : MonoBehaviour
{

    public GameObject lastRoom;
    public OpeningType?[,] map = new OpeningType?[100, 100];
    public GameObject[] rooms;
    public int toPopulate = 30;

    void Start()
    {
        toPopulate = WorldVariables.nOfRooms;
        Invoke("SpawnExit", 3f);
        map[50, 50] = OpeningType.all;
    }
    void SpawnExit()
    {
        lastRoom.GetComponent<RoomManager>().SpawnExit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
