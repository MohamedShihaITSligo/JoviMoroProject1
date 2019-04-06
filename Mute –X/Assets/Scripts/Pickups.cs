using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {

    public int amout;
    public Sprite ammo, health;
    protected SpriteRenderer spriteRenderer;
    protected GameController gameController;

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
}
