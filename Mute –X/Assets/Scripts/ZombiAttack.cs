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
            gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position - new Vector3(
                transform.up.x / 3,
                transform.up.y / 3,
                0
                ));
            //transform.position -=  new Vector3(
            //    transform.up.x/3,
            //    transform.up.y/3,
            //    0
            //    );
            
        }
        else if (tag.Equals("Wall"))
        {
            foreach (ContactPoint2D hit in collision.contacts)
            {
                gameController.DestroyWall(hit.point);
            }
            Debug.Log("Wall hit by:  "+gameObject.name);
        }
    }
}
