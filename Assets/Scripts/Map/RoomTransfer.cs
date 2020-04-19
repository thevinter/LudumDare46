using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransfer : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraFollow cam;
    private bool canTeleport = true;

    private IEnumerator Teleport()
    {
        canTeleport = false;
        yield return new WaitForSeconds(0.5f);
        canTeleport = true;
    }

    private void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (canTeleport)
            {
                StartCoroutine(Teleport());
                cam.minPos += cameraChange;
                cam.maxPos += cameraChange;
                collision.transform.position += playerChange;
            }
            
        }
    }
}
