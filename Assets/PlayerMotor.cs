using UnityEngine;
using System.Collections;

namespace Ruihanyang.Game
{
	public class PlayerMotor : MonoBehaviour
	{
		private Rigidbody2D rigid;

		void Awake ()
		{
			rigid = GetComponent<Rigidbody2D> ();
		}

		public void Move (Vector3 _force)
		{
			rigid.AddForce (_force);
		}

		public void Jump (Vector3 _force)
		{
			rigid.AddForce (_force);
		}
	}
}
