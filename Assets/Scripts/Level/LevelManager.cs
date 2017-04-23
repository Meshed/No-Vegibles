using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
	public GameObject Carrot;
	public float EnemySpawnDelay = 2.0f;
	public Text Points;
	public CanvasGroup GameOverCanvas;

	public enum LevelStates
	{
		Running,
		GameOver
	}

	private LevelGenerator _levelGenerator;
	private EnemySpawner _enemySpawner;
	private float _enemySpawnTimer = 0.0f;
	private int _points = 0;
	private LevelStates _currentLevelState = LevelStates.Running;
	private int _difficultyCounter = 0;

	public delegate void LevelManagerHandler(LevelStates levelState);
	public static event LevelManagerHandler OnStateChange;
	public delegate void LevelManagerDifficulty();
	public static event LevelManagerDifficulty IncreaseDifficulty;

	void Awake()
	{
		_levelGenerator = GetComponent<LevelGenerator> ();
		_enemySpawner = GetComponent<EnemySpawner> ();
	}

	void OnEnable()
	{
		PlayerStateController.OnStateChange += OnPlayerStateChange;
		EnemyController.OnEnemyDestroyed += OnEnemyDestroyed;
	}
	void OnDisable()
	{
		PlayerStateController.OnStateChange -= OnPlayerStateChange;
		EnemyController.OnEnemyDestroyed -= OnEnemyDestroyed;
	}

	void Start () 
	{
		//_levelGenerator.GenerateLevel ();
		//SpawnEnemies ();
	}
	
	void Update () 
	{
		switch (_currentLevelState)
		{
			case LevelStates.Running:
				if (_enemySpawnTimer == 0.0f)
				{
					_enemySpawnTimer = Time.time + EnemySpawnDelay;
				}
				else
				{
					if (Time.time >= _enemySpawnTimer)
					{
						_enemySpawner.SpawnEnemy ();
						_enemySpawnTimer = 0.0f;
					}
				}

				Points.text = _points.ToString ();
				break;
			case LevelStates.GameOver:
				DisplayGameOverPanel ();
				break;
		}
	}

	void OnPlayerStateChange (PlayerStateController.PlayerStates newState)
	{
		switch (newState)
		{
			case PlayerStateController.PlayerStates.Dead:
				_currentLevelState = LevelStates.GameOver;
				if (OnStateChange != null)
				{
					OnStateChange (LevelManager.LevelStates.GameOver);
				}
				break;
			default:
				break;
		}
	}

	void OnEnemyDestroyed(int points)
	{
		_points += points;
	}

	void SpawnEnemies()
	{
		GameObject.Instantiate (Carrot, new Vector3(21, -7, 0), Quaternion.identity);
	}

	void DisplayGameOverPanel()
	{
		GameOverCanvas.alpha = 1;
		GameOverCanvas.blocksRaycasts = true;
		GameOverCanvas.interactable = true;
	}

	public void ReturnToMainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
