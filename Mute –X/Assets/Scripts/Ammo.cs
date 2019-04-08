using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : Pickups {

    protected override void Start()
    {
        base.Start();
        spriteRenderer.sprite = sprite;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag.Equals("Player"))
        {

            data.AddAmmo(amount);
            Destroy(gameObject);
        }
    }
}
