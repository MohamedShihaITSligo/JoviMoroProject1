using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiController : FollowPath {

    bool following = false;

    protected override void Update () {
        // if found the player start following
        base.Update();

        if (detectedPlayer)
        {
            FoundPlayer();
        }
        else if (following)
        {
            LostPlayer();
        }
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        
        if (following)
        {
            // code for zombi attack
            transform.up = currentTarget - body.position;
            body.MovePosition(Vector2.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime));
            body.angularVelocity = 0;
        }
    }

    public void FoundPlayer()
    {
        gameController.PlayerDetected();
        currentTarget = gameController.PlayerLocation().position;
        following = true;
        canMove = !following;
    }
    public void LostPlayer()
    {
        currentTarget = path.GetNodePosition(currentNodeIndex);
        gameController.PlayerUnDetected();
        TeleportToNode();
        following = false;
        canMove = !following;
    }
    
}
