using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    const int MAX_XP = 100;
    const int MaxHealth = 100;
    public int Ammo = 20;
    public int Level = 1 ;
    public float Speed = 3;
    public float Xp = 0;
    public bool Detected = false;
    public int Health;

    private void Start()
    {
        ResetPlayerHealth();
        DontDestroyOnLoad(gameObject);
    }

    public void ResetPlayerHealth()
    {
        Health = MaxHealth;
    }

}
