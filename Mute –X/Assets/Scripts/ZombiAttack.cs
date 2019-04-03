using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ZombiAttack : EnemyAttack
{
    public float attackRate = 2f;
    float elipsedTime;

    private void Update()
    {
        if (attacking)
        {
            if (Vector2.Distance(transform.position, gameController.PlayerLocation().position) > 2)
            {
                attacking = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag.Equals("Player"))
        {
            if (elipsedTime <= Time.time)
            {
                gameController.DamagePlayer(Dameg);
                attacking = true;
                transform.position -= new Vector3(0.2f, 0.2f, 0);
                GetComponent<ZombiController>().Stop();
                elipsedTime = Time.time + attackRate;
            }
        }else if (tag.Equals("Wall"))
        {
            
        }
    }
}
