using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour 
{
	private LevelGenerator _levelGenerator;

	void Awake()
	{
		_levelGenerator = GetComponent<LevelGenerator> ();
	}

	void Start () 
	{
		_levelGenerator.GenerateLevel ();
	}
	
	void Update () {
		
	}
}
