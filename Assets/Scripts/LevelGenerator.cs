using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelGenerator : MonoBehaviour 
{
	public GameObject AboveGroundPlatformTile;
	public GameObject BackgroundDirtTile;
	public GameObject BossRoomTile;
	public GameObject DirtWallEdgeTile;
	public GameObject DirtWallTile;
	public GameObject LadderTile;
	public GameObject RescueRoomTile;

	public void GenerateLevel()
	{
		MapData mapData = LoadJsonData ();
		int mapWidth = mapData.width;

		foreach (MapLayer item in mapData.layers)
		{
			int xCounter = 0;
			int yCounter = 0;
			Debug.Log (item.data.Length);
			foreach (TileSet.TileName blah in item.data) {

				switch (blah)
				{
					case TileSet.TileName.None:
						break;
					case TileSet.TileName.AboveGroundPlatform:
						GameObject.Instantiate (AboveGroundPlatformTile, new Vector3 (xCounter, yCounter, 0), Quaternion.identity);
						break;
					case TileSet.TileName.BackgroundDirtTile:
						GameObject.Instantiate (BackgroundDirtTile, new Vector3 (xCounter, yCounter, 0), Quaternion.identity);
						break;
					case TileSet.TileName.BossRoomTile:
						break;
					case TileSet.TileName.DirtWallTile:
						GameObject.Instantiate (DirtWallTile, new Vector3 (xCounter, yCounter, 0), Quaternion.identity);
						break;
					case TileSet.TileName.LadderTile:
						GameObject.Instantiate (LadderTile, new Vector3 (xCounter, yCounter, 0), Quaternion.identity);
						break;
					case TileSet.TileName.RescueRoomTile:
						GameObject.Instantiate (RescueRoomTile, new Vector3 (xCounter, yCounter, 0), Quaternion.identity);
						break;
					case TileSet.TileName.DirtWallEdgeTile:
						GameObject.Instantiate (DirtWallEdgeTile, new Vector3 (xCounter, yCounter, 0), Quaternion.identity);
						break;
					default:
						break;
				}

				xCounter++;
				if (xCounter == mapWidth)
				{
					xCounter = 0;
					yCounter--;
				}
			}
		}
	}

	private MapData LoadJsonData()
	{
		TextAsset mapJson = Resources.Load (Path.Combine ("LevelMap", "LevelLayout")) as TextAsset;
		MapData map = JsonUtility.FromJson<MapData> (mapJson.text);

		return map;
	}
}
