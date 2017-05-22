using Zenject;
using MemoryGame.Game.Controllers;
using MemoryGame.Game.Models;
using System.Linq;

namespace MemoryGame.Game.Gameplay {
	public class VictoryChecker : IInitializable
	{
		private TurnSignal turnSignal;
		private VictorySignal victorySignal;
		private IGridModel gridModel;
		
		private VictoryChecker (
			TurnSignal turnSignal,
			VictorySignal victorySignal,
			IGridModel gridModel)
		{
			this.turnSignal = turnSignal;
			this.victorySignal = victorySignal;
			this.gridModel = gridModel;
		}

		private void TurnSignal ()
		{
			if (gridModel.Cards.Count (x => !x.Opened) == 1)
				victorySignal.Fire ();
		}

		public void Initialize ()
		{
			turnSignal += TurnSignal;
		}
	}
}