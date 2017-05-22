using System;
using MemoryGame.Game.Models;

namespace MemoryGame.Game.Controllers {
	public class CardEventArgs : EventArgs
	{
		private CardController card;

		public CardEventArgs (CardController card)
		{
			this.card = card;
		}

		public CardController Card {
			get {
				return this.card;
			}
		}
	}
}