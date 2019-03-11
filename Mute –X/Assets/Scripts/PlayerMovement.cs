using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float vertical;
    float horizontal;
    float speed = 5;
    Rigidbody2D body;


    // Use this for initialization
    void Start()
    {


        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, worldMousePos - transform.position);


    }


    private void FixedUpdate()
    {



        body.velocity = new Vector2(horizontal, vertical) * speed;

        body.angularVelocity = 0;
    }

}
