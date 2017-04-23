using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderListener : MonoBehaviour 
{
	public PlayerStateListener targetStateListener = null;

	void OnTriggerEnter2D(Collider2D collidedObject)
	{
		switch (collidedObject.tag)
		{
			case "Platform":
				break;
		}
	}
}
