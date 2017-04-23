using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAround : MonoBehaviour 
{
	void Update () 
	{
		DontDestroyOnLoad (gameObject);
	}
}
