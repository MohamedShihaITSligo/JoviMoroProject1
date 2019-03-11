using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform transformToFollow;
    Vector3 tempPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        tempPosition.x = transformToFollow.position.x;//car x
        tempPosition.y = transformToFollow.position.y;//car y
        tempPosition.z = transform.position.z;//camera z

        transform.position = tempPosition;



    }
}
