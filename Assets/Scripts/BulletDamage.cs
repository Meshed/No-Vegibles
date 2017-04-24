using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour 
{
	public delegate void BulletDamageHandler();
	public static event BulletDamageHandler HitByBullet;
	public EnemyController EnemyController;
	
	void OnTriggerEnter2D(Collider2D collidedObject)
	{
		if (collidedObject.tag == "Bullet")
		{
			gameObject.SendMessage ("HitByBullet", SendMessageOptions.DontRequireReceiver);
			
			if (HitByBullet != null)
			{
				//HitByBullet ();
			}
		}
	}
}
