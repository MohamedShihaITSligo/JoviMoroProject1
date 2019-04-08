using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {

    public int amount;
    public Sprite sprite;
    protected SpriteRenderer spriteRenderer;
    protected GameController gameController;
    protected PlayerData data;
    TextMesh text;

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        data = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        text = GetComponentInChildren<TextMesh>();
    }

    private void Update()
    {
        text.text = ""+amount;
    }

    public void SetAmount(int amount)
    {
        this.amount = amount;
    }
}
