using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoomUtils;

public class RoomTemplates : MonoBehaviour
{

    public OpeningType?[,] map = new OpeningType?[100, 100];
 
    public GameObject[] rooms;
    public GameObject closedRoom;
    void Start()
    {
        map[50, 50] = OpeningType.all;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
