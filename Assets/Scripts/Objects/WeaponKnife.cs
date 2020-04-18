using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponKnife : MonoBehaviour, IFireable
{
    public int Damage { get => damage; set => throw new System.NotImplementedException(); }
    public float BulletSpeed { get => bulletSpeed; set => throw new System.NotImplementedException(); }
    public float BulletDelay { get => bulletDelay; set => throw new System.NotImplementedException(); }

    public int damage;
    public float bulletSpeed;
    public float bulletDelay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() != null)
        {
            collision.GetComponent<IDamageable>().Damage(damage);
        }
    }
}
