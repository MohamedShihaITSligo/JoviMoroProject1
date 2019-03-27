using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController: MonoBehaviour {

    public GameObject mainMenu;
    public GameObject howToPlay;
    public GameObject pauseMenu;
    public GameObject eventSystem;
    public bool paused = false;
    public bool justStarted = false;
    Vector3 startingPoint;
    Slider volume;
    Text txtVolume;
    PlayerData data;
    GameObject player;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        volume = mainMenu.gameObject.GetComponentInChildren<Slider>();
        txtVolume = volume.GetComponentInChildren<Text>();
        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
        pauseMenu.SetActive(false);
        player.SetActive(false);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(pauseMenu);
        DontDestroyOnLoad(eventSystem);
        DontDestroyOnLoad(player);
    }

    private void Update()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index > 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeInHierarchy)
            {
                Pause();
            }
            else Resume();
        }
        switch (index)
        {
            case 1:
                // write level 1 code here 
                if (justStarted)
                {
                    startingPoint = GameObject.FindGameObjectWithTag("StartingPoint").GetComponent<Transform>().position;
                    player.transform.position = startingPoint;
                    justStarted = false;
                }
                break;
            case 2:
                // write level 2 code here 
                break;
            case 3:
                // write level 3 code here 
                break;
            case 4:
                // write level 4 code here
                break;
        }
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

    public void ExitButton()
    {
        Application.Quit();
    }

    public void PlayButton()
    {
        GoToLevel(1);
        player.SetActive(true);
        data = player.GetComponent<PlayerData>();
        
    }

    public void HowToPlay()
    {
        mainMenu.SetActive(false);
        howToPlay.SetActive(true);
    }

    public void BackButton()
    {
        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
    }

    public void UpdateText()
    {
        float value = volume.value * 100;
        txtVolume.text= value.ToString("0")+"%";
    }

    public bool PlayerAlive()
    {
        
        if (data.Health <= 0)
        {
            return false;
        }
        else return true;
    }

    public void GoToLevel(int index)
    {
        SceneManager.LoadScene(index);
        justStarted = true;
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Resume();
        Destroy(gameObject);
        Destroy(pauseMenu);
        Destroy(eventSystem);
        Destroy(player);
    }

    public void RestartLevel()
    {
        player.transform.position = startingPoint;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    public void PlayerDetected()
    {
        data.Detected = true;
    }
    public void PlayerUnDetected()
    {
        data.Detected = false;
    }

    public bool IsPlayerDetected()
    {
        return data.Detected;
    }

    public Transform PlayerLocation()
    {
        return player.transform;
    }
}
