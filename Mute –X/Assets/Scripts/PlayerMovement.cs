using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float vertical;
    Rigidbody2D body;
    PlayerData data;


    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        data = GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        // get the input 
        vertical = Input.GetAxis("Vertical");
        // get the mouse position
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // rotat the player to the mouse direction
        transform.rotation = Quaternion.LookRotation(Vector3.forward, worldMousePos - transform.position);

    }

    private void FixedUpdate()
    {
        // move the player forward with the speed from the data  
        body.velocity = transform.up * vertical * data.Speed;
        body.angularVelocity = 0;
    }

}
