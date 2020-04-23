using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : MonoBehaviour, IFireable
{
    public int Damage { get => this.damage; set => throw new System.NotImplementedException(); }
    public float BulletSpeed { get => this.bulletSpeed; set => throw new System.NotImplementedException(); }
    public float BulletDelay { get => this.bulletDelay; set => throw new System.NotImplementedException(); }
    public AudioClip ShootSound { get => this.sound; set => throw new System.NotImplementedException(); }
    public AudioClip sound;
    public int damage = 1;
    public float bulletSpeed;
    public float bulletDelay;
    public float decayTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, decayTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() != null && !collision.CompareTag("Player"))
        {
            collision.GetComponent<IDamageable>().Damage(damage);
            Destroy(this.gameObject);
        }
    }
}
