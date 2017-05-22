using Zenject;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace MemoryGame.Game.Controllers {
	public class TimerController : MonoBehaviour
	{
		private const string isPulsing = "IsPulsing";

		private Animator animator;
		private Text text;
		private int pulseAfterSeconds;
		private TimeSpan pulseAfterTimeSpan;

		private DateTime endTime;

		[Inject]
		private void Inject (
			Animator animator,
			Text text,
			int pulseAfterSeconds)
		{
			this.animator = animator;
			this.text = text;
			this.pulseAfterTimeSpan = TimeSpan.FromSeconds (pulseAfterSeconds);
		}

		private void Update ()
		{
			TimeSpan timeSpan = endTime.Subtract (DateTime.Now);
			if (timeSpan.CompareTo (TimeSpan.Zero) < 0)
				timeSpan = TimeSpan.Zero;

			text.text = string.Format ("{0:d2}:{1:d2}", timeSpan.Minutes, timeSpan.Seconds);
			if (timeSpan.CompareTo (pulseAfterTimeSpan) < 0
					&& !animator.GetBool (isPulsing))
				animator.SetBool (isPulsing, true);
		}

		public void Run (int seconds)
		{
			Run (0, seconds);
		}

		public void Run (int minutes, int seconds)
		{
			endTime = DateTime.Now.Add (new TimeSpan (0, minutes, seconds));
			animator.SetBool (isPulsing, false);
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