using Zenject;
using MemoryGame.Game.Models;
using System.Collections.Generic;

namespace MemoryGame.Game.Controllers {
	public class GridController
	{
		private CardController.Pool cardControllerPool;
		private IGridModel gridModel;
		private List<CardController> openedCards;
		private LockInteractionSignal lockInteractionSignal;
		private UnlockInteractionSignal unlockInteractionSignal;
		private DelayedAction.Pool delayedActionPool;
		private DelayedAction delayedAction;
		private TurnSignal turnSignal;
		private List<CardController> cardControllers;

		private GridController (
			CardController.Pool cardControllerPool,
			IGridModel gridModel,
			LockInteractionSignal lockInteractionSignal,
			UnlockInteractionSignal unlockInteractionSignal,
			DelayedAction.Pool delayedActionPool,
			TurnSignal turnSignal)
		{
			this.cardControllerPool = cardControllerPool;
			this.gridModel = gridModel;
			this.openedCards = new List<CardController> ();
			this.cardControllers = new List<CardController> ();
			this.lockInteractionSignal = lockInteractionSignal;
			this.unlockInteractionSignal = unlockInteractionSignal;
			this.delayedActionPool = delayedActionPool;
			this.turnSignal = turnSignal;
		}

		private void LockInteraction ()
		{
			lockInteractionSignal.Fire ();	
		}

		private void UnlockInteraction ()
		{
			unlockInteractionSignal.Fire ();
		}

		private void CardControllerTapped (object sender, CardEventArgs e)
		{
			CardController card = e.Card;
			openedCards.Add (e.Card);

			card.Turn ();
			card.Model.Opened = true;
			LockInteraction ();
		}

		private void CardControllerTurned (object sender, CardEventArgs e)
		{
			if (openedCards.Count < 2) {
				UnlockInteraction ();
				return;
			}

			delayedAction = delayedActionPool.Spawn (
				() => CompareCards (openedCards [0], openedCards [1]),
				1f);
		}

		private void CardControllerReturned (object sender, CardEventArgs e)
		{
			e.Card.Returned -= CardControllerReturned;
			UnlockInteraction ();
		}

		private void CardControllerDisappeared (object sender, CardEventArgs e)
		{
			e.Card.Returned -= CardControllerDisappeared;
			UnlockInteraction ();
		}

		private void CompareCards (CardController cardA, CardController cardB)
		{
			if (cardA.Model.Kind == cardB.Model.Kind) {
				turnSignal.Fire ();
				cardA.Disappeared += CardControllerDisappeared;
				cardA.Disappear ();
				cardB.Disappear ();
			} else {
				cardA.Returned += CardControllerReturned;
				cardA.Return ();
				cardB.Return ();
				cardA.Model.Opened = cardB.Model.Opened = false;
			}

			openedCards.Clear ();
			delayedActionPool.QueueForDespawn (delayedAction);
		}

		public void Refresh ()
		{
			foreach (var cardController in cardControllers) {
				cardControllerPool.Despawn (cardController);
			}
			cardControllers.Clear ();
			openedCards.Clear ();

			foreach (var cardModel in gridModel.Cards) {
				CardController cardController = cardControllerPool.Spawn (cardModel);
				cardControllers.Add (cardController);

				cardController.Tapped += CardControllerTapped;
				cardController.Turned += CardControllerTurned;
			}
		}
	}
}