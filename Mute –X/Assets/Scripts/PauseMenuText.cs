using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenuText : MonoBehaviour {

    public TextMeshProUGUI[] text;
    LevelController level;
    private void Start()
    {
        level = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
        text = GetComponentsInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        for (int i = 0; i < level.Objectives.Length; i++)
        {
            text[i].text = level.Objectives[i].Text;
            if (level.Objectives[i].SubText != null)
                text[i].text += level.Objectives[i].SubText;
            if (level.Objectives[i].Done)
            {
                text[i].fontStyle = FontStyles.Strikethrough;
            }
        }

        
    }
}
