using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour 
{
	public float BulletSpeed = 1.0f;
	public float SelfDestructDelay = 1.0f;

	private Rigidbody2D rigidBody;
	private float _selfDestructTimer;

	void Awake()
	{
		rigidBody = GetComponent<Rigidbody2D> ();
		_selfDestructTimer = Time.time + SelfDestructDelay;
	}

	void Update()
	{
		if (Time.time >= _selfDestructTimer)
		{
			Destroy (gameObject);
		}
	}
	
	public void LaunchBullet(bool leftGun)
	{
		Vector2 bulletForce;
		
		if (leftGun)
		{
			bulletForce = new Vector2 (BulletSpeed * -1.0f, 0.0f);
		}
		else
		{
			bulletForce = new Vector2 (BulletSpeed, 0.0f);
		}

		rigidBody.velocity = bulletForce;
	}
}
