using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public GameObject howToPlay;
    public GameObject mainMenu;
    public GameObject eventSystem;
    GameController gameController;
    Slider volume;
    Text txtVolume;
    // Use this for initialization
    void Start () {
        howToPlay.SetActive(false);
        mainMenu.SetActive(true);
        volume = mainMenu.GetComponentInChildren<Slider>();
        txtVolume = volume.GetComponentInChildren<Text>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        DontDestroyOnLoad(eventSystem);
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
        txtVolume.text = value.ToString("0") + "%";
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        gameController.firstLevl = true;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
