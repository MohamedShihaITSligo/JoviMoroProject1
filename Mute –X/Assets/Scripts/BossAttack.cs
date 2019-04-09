using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : EnemyAttack {

    public GameObject gun;
    public GameObject Bullet;
    public float bulletSpeed = 10f;
    public float fireRate = 1.5f;
    public float superFireRate = 0.2f;
    public float reloadTime = 3f;
    public bool reloading = false;
    float elipsedTime;
    float superElipsedTime;
    public int ammo;
    const int FULL_MAGAZIN = 10;


    virtual protected void FixedUpdate()
    {
        bool foundPlayer = GetComponentInChildren<VisionController>().CanPlayerBeSeen();
        if (foundPlayer)
        {
            Shoot();
        }
        else
        {
            elipsedTime = Time.time + fireRate;
            attacking = false;
        }

    }

    virtual protected void Shoot()
    {
        attacking = true;
        if (elipsedTime <= Time.time)
        {
            reloading = false;
            bulletSpeed = 10f;
            InstantiateBullet(0.5f);
            ammo--;
            elipsedTime = Time.time + fireRate;
        }

        if (ammo <= 0)
        {
            reloading = true;
            elipsedTime = Time.time + reloadTime;
            ammo = FULL_MAGAZIN;
        }

        if (reloading)
        {
            if (superElipsedTime <= Time.time)
            {
                InstantiateBullet(3);
                bulletSpeed += 0.01f;
                superElipsedTime = Time.time + superFireRate;
            }
        }
    }

    

    void InstantiateBullet(float timer)
    {
        Vector3 position = new Vector3(
            gun.transform.position.x,
            gun.transform.position.y,
            gun.transform.position.z
            );

       
        // Creates the bullet locally
        GameObject bullet = (GameObject)Instantiate(
                                Bullet,
                                position,
                                Quaternion.identity);
        // Adds velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<Bullet>().SetDamage(Damage);
        bullet.GetComponent<Bullet>().timer = timer;
        bullet.tag = "BulletEnemy";
    }
}
