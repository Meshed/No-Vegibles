using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	public int Health = 1;
	public int Points = 1;
	public float MoveSpeed = 1.0f;
	public AudioClip EnemyHit;
	public AudioClip EnemyDeath;

	private bool _moveLeft = true;
	private GameObject _soundEffectsSource;
	private AudioSource _audioSource;

	public delegate void EnemyControllerHandler (int points);
	public static event EnemyControllerHandler OnEnemyDestroyed;

	void OnEnable()
	{
		//BulletDamage.HitByBullet += HitByBullet;
		LevelManager.OnStateChange += OnLevelStateChange;
	}
	void OnDisable()
	{
		//BulletDamage.HitByBullet -= HitByBullet;
		LevelManager.OnStateChange -= OnLevelStateChange;
	}

	// Use this for initialization
	void Start () 
	{
		if (gameObject.transform.position.x < 0)
		{
			_moveLeft = true;
		}
		else
			_moveLeft = false;
		
		_soundEffectsSource = GameObject.FindGameObjectWithTag ("Sound");
		if (_soundEffectsSource != null)
		{
			_audioSource = _soundEffectsSource.GetComponent<AudioSource> ();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Health <= 0)
		{
			Destroy (gameObject);
			OnEnemyDestroyed (Points);
			PlaySoundEffect (EnemyDeath);
		}

		if (_moveLeft)
		{
			transform.Translate (new Vector3 (MoveSpeed * Time.deltaTime, 0.0f, 0.0f));
		}
		else
			transform.Translate (new Vector3 ((MoveSpeed * -1.0f) * Time.deltaTime, 0.0f, 0.0f));
	}

	void OnLevelStateChange(LevelManager.LevelStates newState)
	{
		switch (newState)
		{
			case LevelManager.LevelStates.GameOver:
				Destroy (gameObject);
				break;
		}
	}

	public void HitByBullet()
	{
		Health--;
		PlaySoundEffect (EnemyHit);
	}

	private void PlaySoundEffect(AudioClip soundEffect)
	{
		if (_audioSource != null)
		{
			_audioSource.PlayOneShot (soundEffect);
		}
		else
			Debug.Log ("No sound audio source found!");
	}
}
