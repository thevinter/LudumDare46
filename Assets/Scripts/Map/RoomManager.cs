using ChrisTutorials.Persistent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject[] doors;
    public GameObject exit;
    int nMonsters = 0;
    public bool isSpawned = false;
    public AudioClip open;
    public AudioClip closed;
    public bool isStarting = false;
    private bool isOpened = false;
    public AudioClip spawnSound;
    public void addMonster()
    {
        nMonsters++;
    }

    public void deleteMonster()
    {
        nMonsters--;
    }
    // Start is called before the first frame update
    public void SpawnExit()
    {
        exit.GetComponent<ISpawner>().Spawn();
    }

    void OpenDoors(bool state)
    {
        if (!state && !isStarting)
        {
            AudioController.PlaySound("doorOpen");
        }
        else
        {
            AudioController.PlaySound("doorClose");
        }
        foreach (GameObject g in doors){
            g.SetActive(!state);
        }
    }

    public void Spawn()
    {
        OpenDoors(false);
        for(int i = 0; i < spawners.Length; i++) 
        {
            if(spawners[i] != null)
                spawners[i].GetComponent<ISpawner>().Spawn();
        }
        AudioManager.Instance.Play(spawnSound, transform, .1f);
        isSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(isSpawned && nMonsters == 0 && !isOpened && !isStarting)
        {
            isOpened = true;
            OpenDoors(true);
        }
    }
}
