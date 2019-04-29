using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour {


    public bool paused = false;
    public GameObject pauseMenu;
    public GameObject lostMenu;
    public GameObject wonMenu;
    public GameObject[] Pickups;
    Vector3 startingPoint;
    Tilemap walls;
    PlayerData data;
    GameObject player;
    LevelController level;


    private void Start()
    {
        lostMenu.SetActive(false);
        pauseMenu.SetActive(false);
        wonMenu.SetActive(false);
    }

    private void Update()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index > 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && PlayerAlive())
            {
                if (!paused)
                {
                    Pause();
                }
                else Resume();
            }

            if (data == null || player == null)
            {
                level = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
                player = GameObject.FindGameObjectWithTag("Player");
                data = player.GetComponent<PlayerData>();
                startingPoint = GameObject.FindGameObjectWithTag("StartingPoint").GetComponent<Transform>().position;
                player.transform.position = startingPoint;
                InstantiateMenus();
                Time.timeScale = 1;
            }

            if (!PlayerAlive())
            {
                paused = true;
                if (lostMenu != null)
                    lostMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void InstantiateMenus()
    {
        lostMenu = Instantiate(lostMenu);
        wonMenu = Instantiate(wonMenu);
        pauseMenu = Instantiate(pauseMenu);
    }

    //UI
    internal void PlayerWon()
    {
        Time.timeScale = 0;
        paused = true;
        wonMenu.SetActive(true);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        paused = !paused;
    }
    
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        paused = !paused;
    }
    public void Continue()
    {
        Resume();
        wonMenu.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void GoToSurvival()
    {
        GoToLevel(SceneManager.sceneCountInBuildSettings-1);
    }
    public void BackToMainMenu()
    {
        Resume();
        Destroy(pauseMenu);
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void RestartLevel()
    {
        Resume();
        Destroy(player);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReTry()
    {
        // respawn from the last checkpoint  ?
        paused = false;
        lostMenu.SetActive(false);
        Time.timeScale = 1;
        // for now just restart the level
        //Destroy(player);
        //Destroy(pauseMenu);
        //Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    // Player
    public void IgnorePlayer(Collider2D Item, bool stet)
    {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), Item, stet);
    }

    public bool PlayerAlive()
    {
        
        if (data.Health <= 0)
        {
            return false;
        }
        else return true;
    }

    public void PlayerDetected()
    {
        if (data != null)
        {
            data.Detected = true;
        }
    }

    public void PlayerUnDetected()
    {
        if (data != null)
        {
            data.Detected = false;
        }
    }

    public bool IsPlayerDetected()
    {
        if(data!=null)
            return data.Detected;
        return false;
    }

    public Transform PlayerLocation()
    {
        if(player != null)
            return player.transform;
        else return null;
    }

    public void DamagePlayer(int amount)
    {
        data.DamegPlayer(amount);
    }

    // Game - level
    public void DestroyWall(Vector3 worldPosition)
    {
        Vector3Int cellPosition = walls.WorldToCell(worldPosition);
        walls.SetTile(cellPosition, null);
    }

    public void EnemyKilled()
    {
        level.SomeoneDied = true;
    }

    internal GameObject DropPickup(Vector3 position, int amount, PickupsType type)
    {
        GameObject pickup;
        pickup = Instantiate(Pickups[(int)type], position, Quaternion.identity);
        pickup.GetComponent<Pickups>().SetAmount(amount);
        return pickup;
    }

    public void PickedUp(GameObject pickup)
    {
        PickupsType type = pickup.GetComponent<Pickups>().Type;
        int amount = pickup.GetComponent<Pickups>().Amount;
        switch (type)
        {
            case PickupsType.Health:
                data.DamegPlayer(amount * -1);
                break;
            case PickupsType.Ammo:
                data.AddAmmo(amount);
                break;
            case PickupsType.Shotgun:
            case PickupsType.Pistol:
            case PickupsType.Machinegun:
                type = player.GetComponent<PlayerAttack>().gun.GetComponent<Weapons>().Type;
                player.GetComponent<PlayerAttack>().gun.GetComponent<Weapons>().Copy(pickup);
                if (type != PickupsType.Nothing)
                {
                    GameObject temp = DropPickup(
                        pickup.transform.position,
                        amount,
                        type
                        );
                    // ignore the player for 15 sec
                    IgnorePlayer(temp.GetComponent<Collider2D>(), true);
                    temp.GetComponent<Weapons>().Dropped();
                }
                break;
        }
    }
}
