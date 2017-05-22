using UnityEngine;
using System;
using Zenject;
using UnityEngine.UI;

namespace MemoryGame.Menu {
	public class ChallengeButtonHintSetter : MonoBehaviour
	{
		private TimeSpan roundDuration;

		[Inject]
		private void Inject (TimeSpan roundDuration)
		{
			Text text = GetComponent<Text> ();
			text.text = string.Format (
				"({0:d2}:{1:d2} to complete task)",
				roundDuration.Minutes,
				roundDuration.Seconds);
		}
	}
}