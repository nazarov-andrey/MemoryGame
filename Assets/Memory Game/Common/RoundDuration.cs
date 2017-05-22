using UnityEngine;
using System;

namespace MemoryGame.Common {
	public class RoundDuration : UnityEngine.Object
	{
		[SerializeField]
		private int minutes;
		[SerializeField]
		private int seconds;

		public TimeSpan TimeSpan {
			get {
				return new TimeSpan (0, minutes, seconds);
			}
		}
	}
}