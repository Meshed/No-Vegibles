using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class MapData
{
	public int height;
	public MapLayer[] layers;
	public int nextobjectid;
	public string orientation;
	public string renderorder;
	public int width;
	public TileSet[] tilesets;
}

[Serializable]
public class TileSet
{
	public enum TileName
	{
		None,
		AboveGroundPlatform,
		BackgroundDirtTile,
		BossRoomTile,
		DirtWallTile,
		LadderTile,
		RescueRoomTile,
		DirtWallEdgeTile
	}
	
	public int firstgid;
	public TileName name;
}

[Serializable]
public class MapLayer
{
	public int[] data;
	public int height;
	public int width;
	public int x;
	public int y;
}
