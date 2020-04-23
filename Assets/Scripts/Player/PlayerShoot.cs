using ChrisTutorials.Persistent;
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

    public void SetWeapon(GameObject w)
    {
        bulletPrefab = w;
        bullet = bulletPrefab.GetComponent<IFireable>();
        bulletSpeed = bullet.BulletSpeed;
        fireDelay = bullet.BulletDelay;
    }


    public bool CanShoot()
    {
        return (Time.time > lastFire + fireDelay);
    }

    public void Shoot(float x, float y)
    {
        print(fireDelay);
        if (CanShoot())
        {
            float s, c;
            s = Mathf.Sqrt(0.5f - x /( 2 * Mathf.Sqrt((x * x) + (y * y))));
            c = Mathf.Sqrt(0.5f + x /( 2 * Mathf.Sqrt((x * x) + (y * y))));
            if (y < 0 && x >= 0) c = -c;
            if(x==-1 && y == -1)
            {
                c = -c;
            }

            AudioManager.Instance.Play(bullet.ShootSound, transform, .05f);
            Quaternion q = new Quaternion(0,0,s , c);

            GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, q) as GameObject;
            print(q);
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
