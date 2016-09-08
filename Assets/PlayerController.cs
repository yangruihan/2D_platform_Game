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
		private float moveForce = 200f;

		[SerializeField]
		private float maxJumpForce = 3000f;
		[SerializeField]
		private float minJumpForce = 1500f;

		private PlayerMotor motor;

		private float jumpKeyPressedTimer = 0f;

		void Awake ()
		{
			motor = GetComponent<PlayerMotor> ();
		}

		void Start ()
		{
			jumpKeyPressedTimer = 0f;
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
			if (Input.GetKey (jumpKey)) {
				jumpKeyPressedTimer += Time.deltaTime;
			}

			if (Input.GetKeyUp (jumpKey)) {
				jumpKeyPressedTimer = jumpKeyPressedTimer >= 1.5f ? 1.5f : jumpKeyPressedTimer;

				float _jumpForce = minJumpForce + (maxJumpForce - minJumpForce) * (jumpKeyPressedTimer / 1.5f);

				print (_jumpForce);

				motor.Jump (new Vector3 (0f, _jumpForce, 0f));

				jumpKeyPressedTimer = 0f;
			}
		}
	}
}