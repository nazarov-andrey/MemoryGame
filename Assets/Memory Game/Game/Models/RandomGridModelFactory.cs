using Zenject;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryGame.Game.Models {
	public class RandomGridModelFactory : IFactory<IGridModel>
	{
		private IList<string> cardKindsProvider;
		private int gridSize;

		private RandomGridModelFactory (
			IList<string> cardKindsProvider,
			int gridSize)
		{
			this.cardKindsProvider = cardKindsProvider;
			this.gridSize = gridSize;
		}

		public IGridModel Create ()
		{
			int pairsCount = gridSize * gridSize / 2;
			List<string> cards = new List<string> (pairsCount * 2);
			for (int i = 0; i < pairsCount; i++) {
				string kind = cardKindsProvider [Random.Range (0, cardKindsProvider.Count)];
				cards.Add (kind);
				cards.Add (kind);
			}

			for (int i = 0; i < 10; i++) {
				cards.Sort (((x, y) => Random.Range (0, 2) - 1));
			}

			return new GridModel (cards);
		}
	}
}