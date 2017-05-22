using UnityEngine;

namespace MemoryGame.Game.Controllers {
	public class GameResultMessageController : MonoBehaviour
	{
		public const string Victory = "Victory";
		public const string Loss = "Loss";

		private void Start ()
		{
			Hide ();
		}

		public void Display ()
		{
			gameObject.SetActive (true);
		}

		public void Hide ()
		{
			gameObject.SetActive (false);
		}
	}
}