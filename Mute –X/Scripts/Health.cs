using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Pickups {

    protected override void Start()
    {
        base.Start();
        spriteRenderer.sprite = sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag.Equals("Player"))
        {
            if (data.Health < 100)
            {
                gameController.DamagePlayer(amount * -1);
                Destroy(gameObject);
            }
        }
    }
}
