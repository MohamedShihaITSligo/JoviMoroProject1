using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : LevelController {

    Objective bossRoom;
    GameObject[] enemies;
    GameController gameController;
    void Start()
    {
        LevelNumber = 4;
        Objectives = new Objective[3];
        Objectives[0] = new Objective("1- Kill all the zombies !! if you can");
        Objectives[1] = new Objective("2- Reach Boss room without being followed by zombies or detected");
        bossRoom = new Objective("Complete mission 1 or 2 to unlock mission  3");
        Objectives[2] = new Objective("3- Kill Magnus ");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        do
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
        while (enemies == null);
        EnemeiesAlive = enemies.Length;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (EnemeiesAlive <= 0)
        {
            Objectives[0].Done = true;
        }
        Objectives[1].Done = !gameController.IsPlayerDetected();
        CheckBossRoom();
        if (!bossRoom.Done)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), gameController.PlayerColider(), false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            
            CheckBossRoom();
            if (!bossRoom.Done)
            {
                Debug.Log(bossRoom.Text);
                return;
            }
        }
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(),collision.collider,true);
    }

    void CheckBossRoom()
    {
        if (Objectives[0].Done || Objectives[1].Done)
        {
            bossRoom.Done = true;
        }else  bossRoom.Done = false;
    }
}
