using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    //public GameObject[] monsters;
    //public RoomManager roomManager;
    //public void Spawn()
    //{
    //    if (monsters.Length != 0)
    //    {
    //        GameObject mToInstantiate = monsters[Random.Range(0, monsters.Length - 1)];
    //        if(mToInstantiate != null)
    //        {
    //            GameObject monster = Instantiate(mToInstantiate, transform.position, Quaternion.identity);
    //            monster.GetComponent<EnemyController>().room = roomManager;
    //            roomManager.addMonster();
    //        }
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        //roomManager = GetComponentInParent<RoomManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
