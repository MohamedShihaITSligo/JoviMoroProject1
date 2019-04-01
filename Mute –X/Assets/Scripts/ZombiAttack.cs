using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiAttack : EnemyAttack
{


    private void Update()
    {
        if (Vector2.Distance(transform.position, gameController.PlayerLocation().position) > 2)
        {
            attacking = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag.Equals("Player"))
        {
            gameController.DamagePlayer(Dameg);
            attacking = true;
            transform.position -= new Vector3(0.5f,0.5f,0);
            GetComponent<ZombiController>().Stop();
        }
    }
}
