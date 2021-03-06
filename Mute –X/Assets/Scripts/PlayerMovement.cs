﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float vertical;
    float horizontal;
    Rigidbody2D body;
    PlayerData data;
    GameController gameController;


    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        data = GetComponent<PlayerData>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameController.paused)
        {
            // get the input 
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
            // get the mouse position
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // rotat the player to the mouse direction
            transform.rotation = Quaternion.LookRotation(Vector3.forward, worldMousePos - transform.position);
        }
    }

    private void FixedUpdate()
    {
        if (!gameController.paused)
        {
            // move the player forward with the speed from the data  
            body.velocity = transform.up * vertical * data.Speed;
            if (horizontal != 0)
            { 
                body.velocity = transform.right * horizontal * data.Speed;
            }
            body.angularVelocity = 0;
        }
    }

}
