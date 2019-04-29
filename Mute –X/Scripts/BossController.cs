using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : GuardController {

	
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (following)
        {
            if (Vector2.Distance(transform.position, gameController.PlayerLocation().position) < 4)
            {
                // stop and shoot
                following = false;
                canMove = false;
            }
            else
            {
                following = true;
                canMove = true;
            }
        }
		
    }

	
}
