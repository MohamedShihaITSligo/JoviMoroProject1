using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aime : MonoBehaviour {

    //public int maxDistance;
    //public int minDistance;
    public Sprite shooting, notShooting;
    SpriteRenderer sprite;
    GameController gameController;
    //Vector3 playerPosition;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }

    private void Update()
    {

        //float distance = Vector2.Distance(playerPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (!gameController.paused)
        {
            Vector2 tempPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = tempPos;
        }
        //Debug.Log(distance);

    }

    public void SetColour(Color newColor)
    {
        sprite.color = newColor;
    }

    void SetSprite(Sprite newSprite)
    {
        sprite.sprite = newSprite;
    }
    
}
