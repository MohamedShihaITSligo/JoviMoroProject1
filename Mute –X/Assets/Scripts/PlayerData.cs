using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    const int MAX_XP = 100;
    const int MaxHealth = 100;
    const int MAX_SPEED = 6;
    public int Ammo = 20;
    public int Level = 1 ;
    public float Speed = 2;
    public float Xp = 0;
    public bool Detected = false;
    public int Health;

    private void Start()
    {
        ResetPlayerData();
    }

    private void Update()
    {
        if (Xp > MAX_XP)
        {
            Xp = 0;
            Level++;
            Speed += Speed/2;
            if (Speed > MAX_SPEED)
            {
                Speed = MAX_SPEED;
            }
        }

    }

    public void ResetPlayerData()
    {
        Health = MaxHealth;
        Detected = false;
        Xp = 0;
    }

    public void DamegPlayer(int amount)
    {
        if (Health > 0)
        {
            Health -= amount;
            Debug.Log("Dameg: "+amount);
        }
        if (Health < 0)
        {
            Health = 0;
        }
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public void AddAmmo(int amount)
    {
        Ammo += amount;
    }


}
