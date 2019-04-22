using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

    public int FULL_MAGAZINE = 9;
    public int Magazine;
    public float Damage;
    public float ReloadRate;
    public float FireRate;
    public float BulletTime;
    public float BulletVelocity;
    public Sprite sprite;
    public GameObject bullet;
    SpriteRenderer spritRenderer;

    private void Start()
    {
        spritRenderer = GetComponent<SpriteRenderer>();
    }
    public void Replace(GameObject Weapon)
    {
        Weapons newWeapon = Weapon.GetComponent<Weapons>();
        FULL_MAGAZINE = newWeapon.FULL_MAGAZINE;
        Magazine = newWeapon.Magazine;
        Damage =  newWeapon.Damage;
        ReloadRate = newWeapon.ReloadRate;
        FireRate = newWeapon.FireRate;
        BulletTime = newWeapon.BulletTime;
        BulletVelocity = newWeapon.BulletVelocity;
        spritRenderer.sprite = newWeapon.sprite;
        bullet = newWeapon.bullet;
    }
}

