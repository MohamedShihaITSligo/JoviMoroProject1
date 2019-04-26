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
			Debug.Log(ammo.GetComponent<Pickups>().Amount);
		}
	}

	public GameObject Drop(GameObject item)
	{
		 return Instantiate(item, transform.position, Quaternion.identity);
	}
}
