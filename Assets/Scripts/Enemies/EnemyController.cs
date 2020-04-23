using ChrisTutorials.Persistent;
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
    public float speed;
    public float attackDistance = 1;
    public float attackRate = 0.5f;
    public GameObject target;
    public int damage = 10;
    public bool canAttack = true;
    public bool isAttacking = false;
    private Renderer r;
    public AudioClip[] monsterDamage;

    public void StartAttacking(bool status, GameObject target)
    {
        this.target = target;
        isAttacking = status;
    }

    public void Damage(int damage)
    {
        AudioManager.Instance.Play(monsterDamage[Random.Range(0,monsterDamage.Length)], gameObject.transform, .05f, 2f);
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
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    public void Decrement()
    {
        room.deleteMonster();
    }

    public void Increment()
    {
        
        room.addMonster();
    }
}
