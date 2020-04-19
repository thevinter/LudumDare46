using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable, ISpawnable
{

    public int Health { get => health; set => throw new System.NotImplementedException(); }
    public RoomManager Room { get => room; set => room=value; }

    public RoomManager room;
    private GameObject player;
    public int chaseDistance;
    public int health = 20;
    public int speed;


    public void Damage(int damage)
    {
        print("Damaging");
        StartCoroutine(TurnRed());
        health -= damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Increment();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private IEnumerator TurnRed()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);

    }

    public void Decrement()
    {
        room.deleteMonster();
        print("killing!");
    }

    public void Increment()
    {
        
        room.addMonster();
    }
}
