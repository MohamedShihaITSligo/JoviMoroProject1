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
        if (killedBy.Equals("Player"))
        {
            Damage = GetComponent<EnemyAttack>().Damage;
            if (hits <= 0)
            {
                if (DropPickup)
                {
                    if (Damage <= 0) Damage = 5;
                    int amount = Damage / 3;
                    if (amount < 5) amount = 5;
                    gameController.DropPickup(transform.position, amount, PickupType);
                }
                Destroy(gameObject);
            }
        }
        
    }
}
