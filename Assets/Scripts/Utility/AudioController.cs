using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioClip doorOpen, doorClose, enemyDeath;
    static AudioSource src;
    float timeDelay;
    bool canPlay = true;
    public AudioClip[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        doorOpen = Resources.Load<AudioClip>("doorOpen");
        doorClose = Resources.Load<AudioClip>("doorClose");
        enemyDeath = Resources.Load<AudioClip>("enemyDeath");

        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay)
        {
            timeDelay = Random.Range(10, 35);
            canPlay = false;
            StartCoroutine(PlaySound());
        }
          
    }

    private IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(timeDelay);
        src.PlayOneShot(sounds[Random.Range(0, sounds.Length-1)]);
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "doorOpen":
                src.PlayOneShot(doorOpen);
                break;
            case "doorClose":   
                src.PlayOneShot(doorClose);
                break;
            case "enemyDeath":
                //src.PlayOneShot(enemyDeath);
                break;
        }
    }
}
