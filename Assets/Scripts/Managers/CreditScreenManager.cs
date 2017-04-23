using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScreenManager : MonoBehaviour 
{
	public AudioClip ButtonClick;
	
	private GameObject _soundEffectsSource;
	private AudioSource _audioSource;

	void Awake()
	{
		_soundEffectsSource = GameObject.FindGameObjectWithTag ("Sound");
		if (_soundEffectsSource != null)
		{
			_audioSource = _soundEffectsSource.GetComponent<AudioSource> ();
		}
	}

	public void ReturnToMainMenu()
	{
		PlaySoundEffect (ButtonClick);
		SceneManager.LoadScene ("MainMenu");
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
