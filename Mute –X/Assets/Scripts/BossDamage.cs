using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : Damageable {
	public GameObject Gun;
	public GameObject Ammo;
	public void OnDestroy()
	{
		if (hits<=0) {
			Drop(Gun);
			GameObject ammo = Instantiate(Ammo, transform.position, Quaternion.identity);
			ammo.GetComponent<Pickups>().SetAmount(100);
		}
	}

	public void Drop(GameObject item)
	{
		  Instantiate(item, transform.position, Quaternion.identity);
	}
}
