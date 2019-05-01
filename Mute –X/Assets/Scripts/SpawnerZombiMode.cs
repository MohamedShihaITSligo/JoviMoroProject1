using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerZombiMode : LevelController {

    public GameObject[] zombies;
    public NavigationPath path;
    public float SpawnRate;
    float elipsedTime;
    void Start()
    {
        Objectives = new Objective[1];
        Objectives[0] = new  Objective("Kill As many as you can !!");
    }
    // Update is called once per frame
    void Update () {
		
        if(Time.time > elipsedTime)
        {
            InstantiateZombie();
            elipsedTime = Time.time + SpawnRate;
        }

        if (SomeoneDied)
        {
            zombiesKilled++;
            Objectives[0].SubText = ("You have Killed  "+zombiesKilled+" Zombies");
            //to do
            // update current text in UI
        }
	}

    void InstantiateZombie()
    {
        // to do
        // set spwan pos
        // spwaon path
        NavigationPath newPath = Instantiate(path , path.transform.position,Quaternion.identity);
        GameObject zombie = Instantiate(zombies[Random.Range(0,zombies.Length-1)]);
        zombie.GetComponent<FollowPath>().path = newPath;
        zombie.GetComponent<EnemyDamage>().DropPickup = true;
        zombie.GetComponent<EnemyDamage>().PickupType = PickupsType.Ammo;
        zombie.GetComponent<EnemyAttack>().MinDamage = 20;
        zombie.GetComponent<EnemyAttack>().MaxDamage = 30;
    }
}
