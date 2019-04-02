using UnityEngine;
using System.Collections;

public class Bullet : Damageable {
    public int Damage = 1;
    // the bullet will be destroyed if it hit anything but the player
    // if it hits the Enemy damage the enemy 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        Damageable damage = collision.GetComponent<Damageable>();
        if (tag.Equals("Enemy"))
        {
            if (damage != null)
            {
                damage.Hit(Damage);
                hits--;
            }
        }
        else if (tag.Equals("Wall"))
        {
            hits--;
        }
    }
    public void SetDamage(int newDamage)
    {
        Damage = newDamage;
    }
    
}
