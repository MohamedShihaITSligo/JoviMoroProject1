using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float bulletVelocity = 10f;
    public float xOffSet = 0.1f;
    public float yOffSet = 0.1f;
    public GameObject gun;
    public GameObject Bullet;
    Aime aime;
    Color aimeColor;
    GameController gameController;
    PlayerData data;
    bool shooting;

    private void Start()
    {
        data = gameObject.GetComponentInParent<PlayerData>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        aime = GameObject.Find("Aime").GetComponentInChildren<Aime>();
    }

    void Update()
    {
        // if the fire button is pressed and we have ammo shoOt !
        if (Input.GetButtonDown("Fire1")&&data.Ammo>0 && !gameController.paused)
        {
            InstantiateBullet();
            data.Ammo--;
            if (data.Ammo <= 0) aimeColor = Color.gray;
            else if (data.Ammo < 10) aimeColor = Color.red;
            else aimeColor = new Color(0,5,0,1);
            shooting = true;
        }
        else
        {
            shooting = false;
        }
        aime.SetColour(aimeColor);
    }

    public bool IsShooting()
    {
        return shooting;
    }

    void InstantiateBullet()
    {

        Vector3 position = new Vector3(
            gun.transform.position.x+xOffSet,
            gun.transform.position.y+yOffSet,
            gun.transform.position.z
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