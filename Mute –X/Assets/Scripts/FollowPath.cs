using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {

    public NavigationPath path;
    public bool PickRandomStartNode = false;
    public bool canMove = true;
    public float moveSpeed = 2f;
    public float distanceToNodeTolerance = 0.2f;
    public float stopDistance;

    Vector2 currentTarget;
    Rigidbody2D body;
    int currentNodeIndex = 0;
    //StopBox stopBox;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        if (PickRandomStartNode)
        {
            currentNodeIndex = Random.Range(1, path.NodeCount - 1);
        }
        GetNextNodePosition();
        TeleportToNode();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position , currentTarget) <= distanceToNodeTolerance)
        {
            GetNextNodePosition();
        }
        //if (TraficLightGreen()) canMove = true;
        //else canMove = false;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            body.MovePosition(Vector2.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime));
        }
        body.angularVelocity = 0;
    }

    void TeleportToNode()
    {
        transform.position = currentTarget;
    }

    void GetNextNodePosition()
    {
        if (currentNodeIndex >= path.NodeCount)
		{
			currentNodeIndex = 0;
		}

		currentTarget = path.GetNodePosition(currentNodeIndex);
        transform.up = currentTarget - body.position;
        currentNodeIndex++;
    }

    //bool TraficLightGreen()
    //{
    //    GameObject[] TraficLights = GameObject.FindGameObjectsWithTag("TrafficLight");
    //    int shortestIndex = -1;
    //    float shortestDistance = float.MaxValue;
    //    for (int i = 0; i < TraficLights.Length; i++)
    //    {
    //        float trafficLightDistance = Vector2.Distance(transform.position, TraficLights[i].transform.position);
    //        if (trafficLightDistance < shortestDistance)
    //        {
    //            shortestDistance = trafficLightDistance;
    //            shortestIndex = i;
    //        }
    //    }
    //    Color TraficLightColor = TraficLights[shortestIndex].GetComponent<TrafficLightController>().GetTrafgicLightState();
    //    float distance = Vector2.Distance(transform.position, TraficLights[shortestIndex].transform.position);
    //    if (distance < stopDistance && TraficLightColor.Equals(Color.red)) return false;
    //    else return true;
    //}
}
