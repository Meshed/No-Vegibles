using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour 
{
	public delegate void BulletDamageHandler();
	public static event BulletDamageHandler HitByBullet;
	
	void OnTriggerEnter2D(Collider2D collidedObject)
	{
		if (collidedObject.tag == "Bullet")
		{
			if (HitByBullet != null)
			{
				Destroy (collidedObject);
				HitByBullet ();
			}
		}
	}
}
