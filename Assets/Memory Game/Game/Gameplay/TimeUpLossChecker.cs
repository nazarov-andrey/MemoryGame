using Zenject;
using MemoryGame.Game.Controllers;
using System;

namespace MemoryGame.Game.Gameplay {
	public class TimeUpLossChecker : IInitializable
	{
		private TimeSpan roundDuration;
		private GameStartSignal gameStartSignal;
		private VictorySignal victorySignal;
		private LossSignal LossSignal;
		private TimerController timerController;
		private DelayedAction.Pool delayedActionPool;
		private DelayedAction delayedAction;

		private TimeUpLossChecker (
			TimeSpan roundDuration,
			MemoryGame.GameStartSignal gameStartSignal,
			MemoryGame.VictorySignal victorySignal,
			LossSignal lossSignal,
			TimerController timerController,
			DelayedAction.Pool delayedActionPool)
		{
			this.roundDuration = roundDuration;
			this.gameStartSignal = gameStartSignal;
			this.victorySignal = victorySignal;
			this.LossSignal = lossSignal;
			this.timerController = timerController;
			this.delayedActionPool = delayedActionPool;
		}

		public void Initialize ()
		{
			gameStartSignal += GameStartSignal;
			victorySignal += VictorySignal;
		}

		private void GameStartSignal ()
		{
			timerController.Display ();
			timerController.Run (roundDuration.Minutes, roundDuration.Seconds);
			delayedAction = delayedActionPool.Spawn (Loss, (float)roundDuration.TotalSeconds);
		}

		private void Cleanup ()
		{
			delayedActionPool.QueueForDespawn (delayedAction);
			timerController.Hide ();
		}

		private void Loss ()
		{
			LossSignal.Fire ();
			Cleanup ();
		}

		private void VictorySignal ()
		{
			Cleanup ();
		}
	}
}