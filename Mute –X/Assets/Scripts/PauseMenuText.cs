using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenuText : MonoBehaviour {

    public TextMeshProUGUI[] text;
    public LevelController level;
    private void Start()
    {
        level = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
    }
    void Update()
    {
        text[0].text = level.Objectives[0].Text;
        text[0].text += "\n  - You killed (" + level.zombiesKilled + ") Zombies\n  - You killed(" + level.guardsKilled + ") Guards";
        text[1].text = level.Objectives[1].Text;
        text[2].text = level.Objectives[2].Text;
        for (int i = 0; i < text.Length; i++)
        {
            if (level.Objectives[i].Done)
            {
                text[i].fontStyle = FontStyles.Strikethrough;
            }
        }
    }
}
