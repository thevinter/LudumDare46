using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject[] doors;
    int nMonsters = 0;
    public bool isSpawned = false;

    public void addMonster()
    {
        print("adding a monster");
        nMonsters++;
    }

    public void deleteMonster()
    {
        nMonsters--;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OpenDoors(bool state)
    {
        foreach(GameObject g in doors){
            g.SetActive(!state);
        }
    }

    public void Spawn()
    {
        OpenDoors(false);
        for(int i = 0; i < spawners.Length; i++) 
        {
            spawners[i].GetComponent<ISpawner>().Spawn();
        }
        isSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("No of monsters is: " + nMonsters);
        if (Input.GetKeyDown(KeyCode.C) && !isSpawned)
        {
            Spawn();
        }
        if(isSpawned && nMonsters == 0)
        {
            OpenDoors(true);
        }
    }
}
