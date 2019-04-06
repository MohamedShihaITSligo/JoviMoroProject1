using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public int LevelNumber;
    protected Objective[]  Objectives;
    protected int KilledEnemies { get; set; }
    protected int EnemeiesAlive { get; set; }
    protected int DetectedCounter { get; set; }
    protected int AmmoGatherd { get; set; }

}

public class Objective
{
    public string Text { get; set; }
    public bool Done { get; set; }

    public Objective(string text)
    {
        this.Text = text;
    }

}
