using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateController : MonoBehaviour 
{
	public enum PlayerStates
	{
		Idle,
		Left,
		Right,
		Attacking,
		Dead,
		Falling
	}

	public int PlayerHealth = 100;
	public Text PlayerHealthText;

	public delegate void PlayerStateHandler(PlayerStateController.PlayerStates newState);
	public static event PlayerStateHandler OnStateChange;

	void LateUpdate()
	{
		float horizontal = Input.GetAxis ("Horizontal");

		if (horizontal != 0f)
		{
			if (horizontal < 0f)
			{
				if (OnStateChange != null)
					OnStateChange (PlayerStateController.PlayerStates.Left);
			}
			else
			{
				if (OnStateChange != null)
					OnStateChange (PlayerStateController.PlayerStates.Right);
			}
		}
		else 
		{
			if (OnStateChange != null) OnStateChange(PlayerStates.Idle);
		}

		float firing = Input.GetAxis ("Fire1");

		if (firing > 0.0f)
			OnStateChange (PlayerStateController.PlayerStates.Attacking);

		if (PlayerHealth <= 0)
		{
			OnStateChange (PlayerStateController.PlayerStates.Dead);
		}

		PlayerHealthText.text = PlayerHealth.ToString ();
	}
}
