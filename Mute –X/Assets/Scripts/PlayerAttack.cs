using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float fireRate = 2f;
    public float reloadRate = 1.5f;
    public GameObject gun;
    float elipsedTime;
    float reloadElipsedTime;
    Aime aime;
    Color aimeColor;
    GameController gameController;
    PlayerData data;
    Weapons gunData;
    bool shooting;
    bool reloading;

    private void Start()
    {
        data = gameObject.GetComponentInParent<PlayerData>();
        gunData = gun.GetComponentInParent<Weapons>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        aime = GameObject.Find("Aime").GetComponentInChildren<Aime>();
    }

    void Update()
    {

        // if the fire button is pressed and we have ammo shoOt !
        if ( !gameController.paused)
        {
            if (Input.GetButton("Fire1")  &&   gunData.Magazine>0 && elipsedTime <= Time.time)
            {
                InstantiateBullet();
                elipsedTime = Time.time + (gunData.FireRate - fireRate);
                shooting = true;
                gunData.Magazine--;
                if (gunData.Magazine <= 0)
                {
                    gunData.Magazine = 0;
                    reloading = true;
                    reloadElipsedTime = Time.time + (gunData.ReloadRate - reloadRate);
                }
            }
            else
            {
                shooting = false;
            }

            if (reloading && reloadElipsedTime <= Time.time)
            {
                
                if(data.Ammo >= gunData.FULL_MAGAZINE)
                {
                    gunData.Magazine = gunData.FULL_MAGAZINE;
                    data.Ammo -= gunData.FULL_MAGAZINE;
                }
                else
                {
                    gunData.Magazine = data.Ammo;
                    data.Ammo = 0;
                }
                reloading = gunData.Magazine <=0;
            }

        }
        
        if (reloading || gunData.Magazine <= 0) aimeColor = Color.gray;
        else if (gunData.Magazine < gunData.FULL_MAGAZINE/2) aimeColor = Color.red;
        else aimeColor = new Color(0, 5, 0, 1);
        aime.SetColour(aimeColor);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag.Equals("Weapon"))
        {
            gunData.Replace(collision.gameObject);
            Destroy(collision.gameObject);
        }

    }

    public bool IsShooting()
    {
        return shooting;
    }

    void InstantiateBullet()
    {
        gun.transform.rotation = Quaternion.LookRotation(Vector3.forward, aime.transform.position - gun.transform.position);
        Vector3 position = new Vector3(
            gun.transform.position.x,
            gun.transform.position.y,
            gun.transform.position.z
            );
        // Creates the bullet locally
        GameObject bullet = (GameObject)Instantiate(
                                gunData.bullet,
                                position,
                                gun.transform.rotation
                                );
        // Adds velocity to the bullet
        //bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * gunData.BulletVelocity;
        bullet.GetComponent<Bullet>().SetDamage(gunData.Damage);
        bullet.GetComponent<Bullet>().timer = gunData.BulletTime;
        //bullet.transform.up = (Vector2)aime.transform.position - bullet.GetComponent<Rigidbody2D>().position;
    }

}