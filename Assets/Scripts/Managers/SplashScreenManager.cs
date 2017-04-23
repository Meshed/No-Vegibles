using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour 
{
	public string SceneToLoad;
	public int TimeToLoad = 1;

	void Start () 
	{
		Invoke ("NextScene", TimeToLoad);
	}

	void NextScene()
	{
		SceneManager.LoadScene (SceneToLoad);
	}
}
