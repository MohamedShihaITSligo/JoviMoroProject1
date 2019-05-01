using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : LevelController {
    public GameObject[] guards;
    GameObject[] enemies;
    GameController gameController;
    float elapsedTime;

    void Start()
    {
        Time.timeScale = 1;
        Objectives = new Objective[3];
        Objectives[0] = new Objective("1- Kill 4 guards");
        Objectives[0].SubText = "\n  - You killed (" + zombiesKilled + ") Zombies\n  - You killed(" + guardsKilled + ") Guards";
        Objectives[1] = new Objective("2- Reach The Boss ");
        Objectives[2] = new Objective("3- Kill Franko");
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


                if (guardsKilled >= 4)
                {
                    Objectives[0].Done = true;
                }
                else
                {

                    if (guardsKilled < 4)
                    {
                        currentObjective = "Kill " + (4 - guardsKilled) + " more guards";
                    }
                    
                }
                SomeoneDied = false;
                
            }
        }
        else if (!Objectives[1].Done)
        {
            // objective 2
            currentObjective = "Go Beat The Boss";
       
       
        }
        else if (!Objectives[2].Done)
        {
            // objective 3
            GameObject boss = GameObject.Find("Boss_Franko");
            if (boss != null)
                currentObjective = Objectives[2].Text.Substring(2);
            else
            {
                Objectives[1].Done = true;
                gameController.PlayerWon("You Have Completed The Level\n");
            }
        }
        else
        {
            currentObjective = "KILL THEM ALL !!";
        }

        Objectives[0].SubText = "\n  - You killed (" + zombiesKilled + ") Zombies\n  - You killed(" + guardsKilled + ") Guards";

    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player" && Objectives[0].Done)
        {
            gameController.IgnorePlayer(gameObject.GetComponent<Collider2D>(), true);
            Objectives[1].Done = true;
            elapsedTime = Time.time + 5;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Objectives[2].Done && Time.time > elapsedTime)
        {
            gameController.IgnorePlayer(GetComponent<Collider2D>(), false);
        }

    }
}
