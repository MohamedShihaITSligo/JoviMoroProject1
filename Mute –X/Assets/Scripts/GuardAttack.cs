﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAttack : EnemyAttack {
    public GameObject gun;
    public GameObject Bullet;
    public float bulletSpeed = 10f;
    public float fireRate = 1.5f;
    float elipsedTime;

    private void FixedUpdate()
    {
        bool foundPlayer = GetComponent<GuardController>().detectedPlayer;
        if (foundPlayer)
        {
            Shoot();
        }
        else
        {
            elipsedTime = Time.time + fireRate/2;
            attacking = false;
        }

    }

    void Shoot()
    {
        attacking = true;
        if (elipsedTime <= Time.time)
        {
            InstantiateBullet();
            elipsedTime = Time.time + fireRate;
        }
        
    }

    void InstantiateBullet()
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
        bullet.GetComponent<Bullet>().SetDamage(Damage);
        bullet.tag = "BulletEnemy";
    }
}
