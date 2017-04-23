using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour 
{
	public AudioClip MenuClick;

	private GameObject _soundEffectsSource;
	
	void Awake()
	{
		_soundEffectsSource = GameObject.FindGameObjectWithTag ("Sound");
	}
	
	public void PlayGame()
	{
		PlayMenuClick ();
		SceneManager.LoadScene ("Level");
	}

	public void DisplayCredits()
	{
		PlayMenuClick ();
		SceneManager.LoadScene ("Credits");
	}

	private void PlayMenuClick()
	{
		if (_soundEffectsSource != null)
		{
			_soundEffectsSource.GetComponent<AudioSource> ().PlayOneShot (MenuClick);
		}
		else
			Debug.Log ("No sound effects source found!");
	}
}
