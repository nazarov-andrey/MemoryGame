using System;
using System.Collections.ObjectModel;

namespace MemoryGame.Game.Models {
	public class GridModelWrapper : IGridModel
	{
		private IGridModel wrappee;

		public void SetWrappee (IGridModel wrappee)
		{
			if (wrappee == this)
				throw new ArgumentException ("wrapper and wrapee should be different objects");

			this.wrappee = wrappee;
		}

		public ReadOnlyCollection<CardModel> Cards {
			get {
				if (wrappee == null)
					throw new InvalidOperationException ("wrapee should be set before requesting Cards");

				return wrappee.Cards;
			}
		}
	}
}