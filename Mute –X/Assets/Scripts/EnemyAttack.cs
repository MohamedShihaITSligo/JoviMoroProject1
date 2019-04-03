using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public int MinDameg, MaxDameg;
    public bool attacking = false;
    protected GameController gameController;
    public int Dameg;
    
    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Dameg = Random.Range(MinDameg, MaxDameg);
    }
}
