using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    private IFireable bullet;
    private float bulletSpeed;
    private float fireDelay;
    public float lastFire;


    public bool CanShoot()
    {
        return (Time.time > lastFire + fireDelay);
    }

    public void Shoot(float x, float y)
    {
        if (CanShoot())
        {
            float w = Mathf.Atan(y / x);
            GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.FromToRotation(new Vector3(1,0,0), new Vector3(x,y,0))) as GameObject;
            
            bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(
                (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
                (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
                0
            );
            lastFire = Time.time;
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        bullet = bulletPrefab.GetComponent<IFireable>();
        bulletSpeed = bullet.BulletSpeed;
        fireDelay = bullet.BulletDelay;

    }
}
