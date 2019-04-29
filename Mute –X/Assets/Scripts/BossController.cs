using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : GuardController {

	
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (following)
        {
            // keep away fro the player 
            if (Vector2.Distance(transform.position, gameController.PlayerLocation().position) < 2)
            {
                
                //following = false;
                canMove = false;
            }
            else
            {
                //following = true;
                canMove = true;
            }
        }
		
    }

	
}
