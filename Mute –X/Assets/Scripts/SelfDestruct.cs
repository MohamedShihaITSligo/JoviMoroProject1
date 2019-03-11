using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	public float timer = 1f;

	void Update () {
        // if the bullet did not hit anything for 'timer' get destroyed
		timer -= Time.deltaTime;
		if(timer <= 0) {
			Destroy(gameObject);
		}
	}
    // the bullet will be destroyed if it hit anything but the player
    // if it hits the Enemy destroy the enemy 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (tag.Equals("Wall"))
        {
            Destroy(gameObject);
        }
    }
    
}
