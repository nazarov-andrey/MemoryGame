using MemoryGame.Game.Controllers;
using MemoryGame.Game.Models;
using Zenject;
using UnityEngine;

namespace MemoryGame.Game.Gameplay {
	public class Game : IInitializable
	{
		private GridController gridController;
		private GridModelFactory gridModelFactory;
		private GridModelWrapper gridModelWrapper;
		private GameStartSignal gameStartSignal;
		private VictorySignal victorySignal;
		private LossSignal lossSignal;
		private GameResultMessageController victoryMessageController;
		private GameResultMessageController lossMessageController;
		private DelayedAction.Pool delayedActionPool;
		private DelayedAction delayedAction;

		private Game (
			GridController gridController,
			GridModelFactory gridModelFactory,
			GridModelWrapper gridModelWrapper,
			GameStartSignal gameStartSignal,
			VictorySignal victorySignal,
			LossSignal lossSignal,
			[Inject (Id = GameResultMessageController.Victory)] GameResultMessageController victoryMessageController,
			[Inject (Id = GameResultMessageController.Loss)] GameResultMessageController lossMessageController,
			DelayedAction.Pool delayedActionPool)
		{
			this.gridController = gridController;
			this.gridModelFactory = gridModelFactory;
			this.gridModelWrapper = gridModelWrapper;
			this.gameStartSignal = gameStartSignal;
			this.victorySignal = victorySignal;
			this.lossSignal = lossSignal;
			this.victoryMessageController = victoryMessageController;
			this.lossMessageController = lossMessageController;
			this.delayedActionPool = delayedActionPool;
		}

		public void Start ()
		{
			gridModelWrapper.SetWrappee (gridModelFactory.Create ());
			gridController.Refresh ();
			gameStartSignal.Fire ();
		}

		public void Initialize ()
		{
			victorySignal += VictorySignal;
			lossSignal += LossSignal;

			Start ();
		}

		private void Restart (GameResultMessageController gameResultMessageController)
		{
			gameResultMessageController.Hide ();
			delayedActionPool.QueueForDespawn (delayedAction);

			Start ();
		}

		private void DisplayGameResult (GameResultMessageController gameResultMessageController)
		{
			gameResultMessageController.Display ();
			delayedAction = delayedActionPool.Spawn (() => Restart (gameResultMessageController), 2f);
		}

		private void VictorySignal ()
		{
			DisplayGameResult (victoryMessageController);
		}

		private void LossSignal ()
		{
			DisplayGameResult (lossMessageController);
		}
	}
}