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
            if (Vector2.Distance(transform.position, gameController.PlayerLocation().position) >= 2)
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
                elipsedTime = Time.time + attackRate;
                
            }
            transform.position -=  new Vector3(
                transform.up.x/3,
                transform.up.y/3,
                0
                );
            
        }
        else if (tag.Equals("Wall"))
        {
            
            //Vector3Int tilePos = new Vector3Int(
            //    (int)collision.gameObject.GetComponent<TilemapCollider2D>().bounds.center.x,
            //    (int)collision.gameObject.GetComponent<TilemapCollider2D>().bounds.center.y,
            //    (int)collision.gameObject.GetComponent<TilemapCollider2D>().bounds.center.z
            //    );
            //gameController.DestroyWall(tilePos);
            //Debug.Log("Wall: "+tilePos);
        }
    }
}
