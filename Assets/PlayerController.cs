using UnityEngine;
using System.Collections;

namespace Ruihanyang.Game
{
	[RequireComponent (typeof(Player))]
	[RequireComponent (typeof(PlayerMotor))]
	public class PlayerController : MonoBehaviour
	{
		[SerializeField]
		private KeyCode jumpKey = KeyCode.Space;

		[SerializeField]
		private float moveForce = 120f;

		[SerializeField]
		private float jumpForce = 200f;

		private PlayerMotor motor;

		void Awake ()
		{
			motor = GetComponent<PlayerMotor> ();
		}

		void Update ()
		{
			Move ();

			Jump ();
		}

		void Move ()
		{
			float _xMov = Input.GetAxis ("Horizontal");

			motor.Move (new Vector3 (_xMov * moveForce, 0f, 0f));
		}

		void Jump ()
		{
			if (Input.GetKeyDown (jumpKey)) {
				motor.Jump (new Vector3 (0f, jumpForce, 0f));
			}
		}
	}
}