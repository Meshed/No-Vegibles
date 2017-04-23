using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateListener : MonoBehaviour 
{
	public GameObject LeftBulletSpawnPoint;
	public GameObject RightBulletSpawnPoint;
	public GameObject Bullet;
	public float PlayerWalkSpeed = 1.0f;
	public float PlayerJumpForceHorizontal = 250f;
	public float PlayerJumpForceVertical = 500f;
	public float BulletFiringDelay = 1.0f;

	private PlayerStateController _playerStateController;
	private PlayerStateController.PlayerStates _previousState;
	private PlayerStateController.PlayerStates _currentState;
	private bool _playerHasLanded = true;
	private Rigidbody2D rigidBody;
	private bool _lastMovedLeft = true;
	private float _bulletFiringTimer = 0.0f;

	void Awake()
	{
		rigidBody = GetComponent<Rigidbody2D> ();
		_playerStateController = GetComponent<PlayerStateController> ();
	}
	void OnEnable()
	{
		PlayerStateController.OnStateChange += OnStateChange;
	}
	void OnDisable()
	{
		PlayerStateController.OnStateChange -= OnStateChange;
	}
	void LateUpdate () 
	{
		OnStateCycle ();
	}

	private void OnStateCycle()
	{
		switch (_currentState)
		{
			case PlayerStateController.PlayerStates.Attacking:
				break;
			case PlayerStateController.PlayerStates.Dead:
				break;
			case PlayerStateController.PlayerStates.Idle:
				break;
			case PlayerStateController.PlayerStates.Left:
				transform.Translate (new Vector3 ((PlayerWalkSpeed * -1.0f) * Time.deltaTime, 0.0f, 0.0f));
				break;
			case PlayerStateController.PlayerStates.Right:
				transform.Translate (new Vector3 (PlayerWalkSpeed * Time.deltaTime, 0.0f, 0.0f));
				break;
			case PlayerStateController.PlayerStates.Falling:
				break;
		}
	}

	public void OnStateChange(PlayerStateController.PlayerStates newState)
	{
		if (_currentState == newState)
			return;

		if (!CheckForValidStatePair (newState))
			return;
		
		switch (newState)
		{
			case PlayerStateController.PlayerStates.Attacking:
				if (_bulletFiringTimer == 0.0f)
				{
					_bulletFiringTimer = Time.time + BulletFiringDelay;
				}
				else
				{
					if (Time.time >= _bulletFiringTimer)
					{
						FireBullet ();
						_bulletFiringTimer = 0.0f;
					}
				}

				OnStateChange (_currentState);
				break;
			case PlayerStateController.PlayerStates.Dead:
				break;
			case PlayerStateController.PlayerStates.Idle:
				break;
			case PlayerStateController.PlayerStates.Left:
				_lastMovedLeft = true;
				break;
			case PlayerStateController.PlayerStates.Right:
				_lastMovedLeft = false;
				break;
			case PlayerStateController.PlayerStates.Falling:
				break;
		}

		_previousState = _currentState;
		_currentState = newState;
	}

	private bool CheckForValidStatePair(PlayerStateController.PlayerStates newState)
	{
		bool returnValue = false;

		switch (_currentState)
		{
			case PlayerStateController.PlayerStates.Attacking:
				returnValue = true;
				break;
			case PlayerStateController.PlayerStates.Dead:
				break;
			case PlayerStateController.PlayerStates.Idle:
				returnValue = true;
				break;
			case PlayerStateController.PlayerStates.Left:
				returnValue = true;
				break;
			case PlayerStateController.PlayerStates.Right:
				returnValue = true;
				break;
			case PlayerStateController.PlayerStates.Falling:
				break;
		}

		return returnValue;
	}

	private void FireBullet()
	{
		Vector3 bulletSpawnPoint;

		if (_lastMovedLeft)
			bulletSpawnPoint = LeftBulletSpawnPoint.transform.position;
		else
			bulletSpawnPoint = RightBulletSpawnPoint.transform.position;

		GameObject bullet = GameObject.Instantiate (Bullet, bulletSpawnPoint, Quaternion.identity);
		BulletController bulletController = bullet.GetComponent<BulletController> ();
		bulletController.LaunchBullet (_lastMovedLeft);
	}

	public void HitByEnemy()
	{
		_playerStateController.PlayerHealth -= 20;
	}
}
