using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float horizontal, vertical;
    Rigidbody2D body;
    

    void Start () {
        body = GetComponent<Rigidbody2D>();
    }
	
	
	void Update () {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, -(horizontal * 2));
        body.velocity = transform.up * vertical * 5;
        if (vertical == 0)  body.velocity = Vector2.zero;
        body.angularVelocity = 0;
    }

}

