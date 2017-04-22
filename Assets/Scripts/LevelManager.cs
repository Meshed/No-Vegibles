using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour 
{
	public GameObject AboveGroundPlatformTile;
	public GameObject BackgroundDirtTile;
	public GameObject BossRoomTile;
	public GameObject DirtWallEdgeTile;
	public GameObject DirtWallTile;
	public GameObject LadderTile;
	public GameObject RescueRoomTile;

	private const int LevelHeight = 100;
	private const int LevelWidth = 300;

	// Use this for initialization
	void Start () 
	{
		GenerateLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GenerateLevel()
	{
		Debug.Log ("Generate Level called");

		// Build first 8 rows
		for (int y = 0; y < 8; y++)
		{
			for (int x = 0; x < 8; x++) {
				if (y == 0)
				{
					GameObject.Instantiate (DirtWallEdgeTile, new Vector3 (292 + y, 8 - x, 0), Quaternion.identity);
				}
				else
				{
					GameObject.Instantiate (DirtWallTile, new Vector3 (292 + y, 8 - x, 0), Quaternion.identity);
				}
			}
		}

		// Build above ground platform level
		for (int x = 0; x < 300; x++)
		{
			switch (x)
			{
				case 153:
				case 154:
				case 156:
				case 157:
					GameObject.Instantiate (BackgroundDirtTile, new Vector3 (x, 0, 0), Quaternion.identity);
					break;
				case 155:
					GameObject.Instantiate (LadderTile, new Vector3 (x, 0, 0), Quaternion.identity);
					break;
				case 292:
				case 293:
				case 294:
				case 295:
				case 296:
				case 297:
				case 298:
				case 299:
					GameObject.Instantiate (DirtWallTile, new Vector3 (x, 0, 0), Quaternion.identity);
					break;
				default:
					GameObject.Instantiate (AboveGroundPlatformTile, new Vector3 (x, 0, 0), Quaternion.identity);
					break;
			}
		}
	}
}
