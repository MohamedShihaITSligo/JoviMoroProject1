using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public int MinDamage, MaxDamage;
    public bool attacking = false;
    protected GameController gameController;
    public int Damage;
    
    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Damage = Random.Range(MinDamage, MaxDamage);
    }
   
    private void OnDestroy()
    {
        gameController.PlayerUnDetected();
    }
}
