using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 -> bottom
    //2 -> left
    //3 -> top
    //4 -> right

    private RoomTemplates templates;
    private bool spawned = false;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>() ;
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (!spawned)
        {
            int x = Mathf.RoundToInt(transform.position.x / 10);
            int y = Mathf.RoundToInt(transform.position.y / 10);
            //switch (openingDirection)
            //{
            //    case 1:
            //        CheckNeigh
            //        Instantiate(templates.bottomRooms[Random.Range(0, templates.bottomRooms.Length)], transform.position, Quaternion.identity);
            //        templates.map[coord / 10] = openingDirection * 2;
            //        break;
            //    case 2:
            //        Instantiate(templates.leftRooms[Random.Range(0, templates.leftRooms.Length)], transform.position, Quaternion.identity);
            //        //door with a left opening
            //        break;
            //    case 3:
            //        Instantiate(templates.topRooms[Random.Range(0, templates.topRooms.Length)], transform.position, Quaternion.identity);
            //        //door with a top opening
            //        break;
            //    case 4:
            //        Instantiate(templates.rightRooms[Random.Range(0, templates.rightRooms.Length)], transform.position, Quaternion.identity);
            //        //door with a right opening
            //        break;
            //    default:
            //        Debug.LogWarning("Wrong room spawnpoint!");
            //        break;
            //}

            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            if(!collision.GetComponent<RoomSpawner>().spawned && !spawned)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
