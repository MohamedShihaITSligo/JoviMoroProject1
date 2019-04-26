using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {

	public float hits;
    public string killedBy;

    virtual protected void Update()
    {
        if (hits <= 0)
        {
            Destroy(gameObject);
        }
    }

	public void Hit(float amount, string tag)
	{
		hits -= amount;
		if (hits <= 0)
		{
			killedBy = tag;
		}
	}
}
