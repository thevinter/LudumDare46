using ChrisTutorials.Persistent;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{

    public int Health { get => health; set => throw new System.NotImplementedException(); }
    public RoomManager Room { get => room; set => room=value; }

    public RoomManager room;
    public int chaseDistance;
    public int health = 20;
    public float speed;
    public float attackDistance = 1;
    public float attackRate = 0.5f;
    public GameObject target;
    public int damage = 10;
    public bool canAttack = true;
    public bool isAttacking = false;
    public AudioClip[] monsterDamage;

    public void StartAttacking(bool status, GameObject target) {
        this.target = target;
        isAttacking = status;
    }

    public void Damage(int damage) {
        AudioManager.Instance.Play(monsterDamage[Random.Range(0,monsterDamage.Length)], gameObject.transform, .05f, 2f);
        _ = TurnRed();
        health -= damage;
    }

    private async Task TurnRed() {
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        await Task.Delay(100); 
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
