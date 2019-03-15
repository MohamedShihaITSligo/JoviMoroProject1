using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController: MonoBehaviour {

    public GameObject mainMenu;
    public GameObject howToPlay;
    Slider volume;
    Text txtVolume;

    private void Start()
    {
        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
        volume = mainMenu.gameObject.GetComponentInChildren<Slider>();
        txtVolume = volume.GetComponentInChildren<Text>();
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
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
}
