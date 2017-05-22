using System;

namespace MemoryGame.Game.Models {
	public class CardModel
	{
		private string kind;
		private bool opened;

		public CardModel (string kind)
		{
			this.kind = kind;
		}

		public string Kind {
			get {
				return this.kind;
			}
		}

		public bool Opened {
			get {
				return this.opened;
			}
			set {
				opened = value;
			}
		}
	}
}