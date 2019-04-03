using UnityEngine;
using System.Collections;

public class Bullet : Damageable {
    public int Damage = 1;
    public float timer = 3f;
    // the bullet will be destroyed if it hit anything 
    // if it hits the Enemy damage the enemy 

    protected override void Update()
    {
        base.Update();
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag.Equals("Enemy"))
        {
            if (!gameObject.tag.EndsWith(tag))
            {
                Attack(collision);
            }
        }
        else if (tag.Equals("Player"))
        {
            collision.GetComponent<PlayerData>().DamegPlayer(Damage);
            hits--;
        }
        else if(tag.Equals("Wall"))
        {
            hits--;
        }
    }
    public void SetDamage(int newDamage)
    {
        Damage = newDamage;
    }
    
    void Attack(Collider2D collision) {
        Damageable damage = collision.GetComponent<Damageable>();
        if (damage != null)
        {
            damage.Hit(Damage);
            hits--;
        }
    }
}
