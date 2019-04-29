using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieAi : MonoBehaviour {
	FollowPath path;
	ZombieData data;
	VisionController vision;
	GameObject Player;
	GameObject Zombie;
	public float speed= 2f;
	public float velocity;
	public float range;

	


	

	
	// Use this for initialization
	void Start () {

		Zombie = GameObject.FindGameObjectWithTag("Zombie");

		Player = GameObject.FindGameObjectWithTag("Player");
		
	}

	// Update is called once per frame
	void Update()
	{


		//follow player if in range
		range = Vector2.Distance(transform.position, Player.transform.position);


		if (range <= 5)
		{
			//face the player
			Vector3 targetPosition = Player.transform.position;
			Vector3 dir = targetPosition - this.transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

			Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * speed, (transform.position.y - Player.transform.position.y) * speed);
			GetComponent<Rigidbody2D>().velocity = -velocity;
		}
		
		



	}

		//transform.LookAt(target.position);
		//transform.Rotate(new Vector3(0, 0, 0), Space.Self);
		//transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);

		//if (Vector2.Distance(transform.position,target.position)>range)
		//{
		//	currentSpeed = chaseSpeed * Time.deltaTime;
		//	transform.position = Vector2.MoveTowards(transform.position, target.position,currentSpeed);
		//}
	
	
	
}
