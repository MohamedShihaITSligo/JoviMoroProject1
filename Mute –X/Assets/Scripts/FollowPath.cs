using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {

    public NavigationPath path;
    public bool PickRandomStartNode = false;
    public bool detectedPlayer = false;
    public float moveSpeed = 2f;
    int currentNodeIndex = 0;
    public float distanceToNodeTolerance = 0.2f;
    Vector2 currentTarget;
    Rigidbody2D body;
    GameController gameController;
    bool following = false;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
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
        if (Vector2.Distance(transform.position , currentTarget) <= distanceToNodeTolerance )
        {
            GetNextNodePosition();
        }

        if (detectedPlayer)
        {
            FoundPlayer();
        }else if (following)
        {
            LostPlayer();
        }
    }

    private void FixedUpdate()
    {
        body.MovePosition(Vector2.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime));
        body.angularVelocity = 0;
    }

    void TeleportToNode()
    {
        transform.position = currentTarget;
    }

    void GetNextNodePosition()
    {
        if (currentNodeIndex >= path.NodeCount) currentNodeIndex = 0;
        currentTarget = path.GetNodePosition(currentNodeIndex);
        transform.up = currentTarget - body.position;
        currentNodeIndex++;
    }

    public void FoundPlayer()
    {
        gameController.PlayerDetected();
        currentTarget = gameController.PlayerLocation().position;
        following = true;
    }
    public void LostPlayer()
    {
        currentTarget = path.GetNodePosition(0);
        gameController.PlayerUnDetected();
        TeleportToNode();
        following = false;
    }
}
