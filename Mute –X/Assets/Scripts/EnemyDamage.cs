using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : Damageable {
    public bool DropPickup;
    public int PickupType;
    int Damage;
    GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    protected override void Update()
    { 
            if (hits <= 0)
            {
                if (DropPickup)
                {
					Damage = GetComponent<EnemyAttack>().Damage;
					if (Damage <= 0) Damage = 5;
                    int amount = Damage / 3;
                    if (amount < 10) amount = 10;
                    gameController.DropPickup(transform.position, amount, PickupType);
                }
                Destroy(gameObject);
            }
    }
}
