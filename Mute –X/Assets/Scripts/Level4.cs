using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : LevelController {
    public GameObject[] guards;
    GameObject[] enemies;
    GameController gameController;
    //int zombiesCount;
    //int guardsCount;
    void Start()
    {
        Objectives = new Objective[3];
        Objectives[0] = new Objective("1- Kill 4 zombies and 4 guards");
        Objectives[1] = new Objective("2- Reach Boss room without being followed by zombies ");
        Objectives[2] = new Objective("3- Kill Magnus (the Big Boss)");
        currentObjective = Objectives[0].Text.Substring(2);
        for (int i = 0; i < Objectives.Length; i++)
        {
            Objectives[i].Done = false;
        }
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        do
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
        while (enemies == null);
        EnemeiesAlive = enemies.Length;
        //guardsCount = guards.Length;
        //zombiesCount = enemies.Length - guardsCount;
    }

    private void Update()
    {
        // objective 1
        if (!Objectives[0].Done)
        {
            
            if (SomeoneDied)
            {

                int guardsNull = 0;
                for (int i = 0; i < guards.Length; i++)
                {
                    if (guards[i] != null)
                    {
                        if (guards[i].GetComponent<Damageable>().hits <= 0)
                        {
                            guardsKilled++;
                        }
                    }
                    else
                    {
                        guardsNull++;
                    }
                }
                if (guardsNull > guardsKilled)
                {
                    guardsKilled++;
                }
                else
                {
                        zombiesKilled++;
                }

                if (zombiesKilled >=4 && guardsKilled >= 4)
                {
                    Objectives[0].Done = true;
                }
                else
                {

                    if (zombiesKilled < 4)
                    {
                        currentObjective = "Kill " + (4 - zombiesKilled) + " more zombies";
                    }
                    else
                    {
                        currentObjective = "Kill " + (4 - guardsKilled) + " more guards";
                    }
                }
                SomeoneDied = false;
                
            }
        }
        else if (gameController.IsPlayerDetected() || !Objectives[1].Done)
        {
            // objective 2
            currentObjective = "Lose the Zombies or Kill them";
            gameController.IgnorePlayer(gameObject.GetComponent<Collider2D>(), false);
        }
        else if (!Objectives[2].Done)
        {
            // objective 3
            GameObject boss = GameObject.Find("Boss");
            if (boss != null)
                currentObjective = Objectives[2].Text.Substring(2);
            else
            {
                Objectives[2].Done = true;
                gameController.PlayerWon();
            }
        }
        else
        {
            currentObjective = "KILL THEM ALL !!";
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Objectives[1].Done = !gameController.IsPlayerDetected();
            gameController.IgnorePlayer(gameObject.GetComponent<Collider2D>(), Objectives[1].Done);
        }
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(),collision.collider,true);
    }

    
}
