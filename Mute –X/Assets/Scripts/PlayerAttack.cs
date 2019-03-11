using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float bulletVelocity = 10f;
    public float xOffSet = 0.5f;
    public float yOffSet = 0.5f;
    public GameObject Bullet;
    PlayerData data;

    private void Start()
    {
        data = gameObject.GetComponentInParent<PlayerData>();
    }

    void Update()
    {
        // if the fire button is pressed and we have ammo shoOt !
        if (Input.GetButtonDown("Fire1")&&data.Ammo>0)
        {
            InstantiateBullet();
            data.Ammo--;
        }
    }


    void InstantiateBullet()
    {
        // i still don't know how to fix the pos of the bullet to the gun this is why i am using the off set 
        Vector3 position = new Vector3(
            transform.position.x+xOffSet,
            transform.position.y+yOffSet,
            transform.position.z
            );  
        // Creates the bullet locally
        GameObject bullet = (GameObject)Instantiate(
                                Bullet,
                                position,
                                Quaternion.identity);
        // Adds velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletVelocity;
    }

}