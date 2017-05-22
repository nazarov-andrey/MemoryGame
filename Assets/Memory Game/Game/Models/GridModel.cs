using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MemoryGame.Game.Models {
	public class GridModel : IGridModel
	{
		private List<CardModel> cards;

		public GridModel (IEnumerable<string> cardKinds)
		{
			cards = new List<CardModel> ();
			foreach (var cardKind in cardKinds) {
				cards.Add (new CardModel (cardKind));
			}
		}

		public ReadOnlyCollection<CardModel> Cards {
			get {
				return cards.AsReadOnly ();
			}
		}
	}
}
