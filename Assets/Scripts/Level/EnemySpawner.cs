using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
	public GameObject[] SpawnPoints;
	public GameObject[] Enemies;

	public void SpawnEnemy()
	{
		GameObject spawnPoint = SpawnPoints [Random.Range (0, SpawnPoints.Length)];
		GameObject enemyToSpawn = Enemies [Random.Range (0, Enemies.Length)];

		GameObject.Instantiate (enemyToSpawn, spawnPoint.transform);
	}
}
