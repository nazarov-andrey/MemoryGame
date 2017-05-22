using TouchScript.Gestures;
using UnityEngine;
using Zenject;
using System;
using MemoryGame.Game.Models;

namespace MemoryGame.Game.Controllers {
	public class CardController : MonoBehaviour
	{
		public class Pool : MemoryPool<CardModel, CardController>
		{
			protected override void Reinitialize (CardModel model, CardController controller)
			{
				base.Reinitialize (model, controller);
				controller.Model = model;
				controller.Turned = null;
				controller.Returned = null;
				controller.Tapped = null;
				controller.Disappeared = null;
			}
		}

		private const string turnTrigger = "Turn";
		private const string returnTrigger = "Return";
		private const string disappearTrigger = "Disappear";
		private const string initialTrigger = "Initial";

		private Animator animator;
		private CardView view;
		private CardModel model;
		private TapGesture tapGesture;

		[Inject]
		private void Inject (
			Animator animator,
			CardView view,
			TapGesture tapGesture)
		{
			this.animator = animator;
			this.view = view;
			this.tapGesture = tapGesture;

			Initialize ();
		}

		private void Initialize ()
		{
			tapGesture.Tapped += TapGestureTapped;
		}

		protected virtual void OnTapped (CardEventArgs e)
		{
			var handler = this.Tapped;
			if (handler != null)
				handler (this, e);
		}

		protected virtual void OnTurned (CardEventArgs e)
		{
			var handler = this.Turned;
			if (handler != null)
				handler (this, e);
		}

		protected virtual void OnReturned (CardEventArgs e)
		{
			var handler = this.Returned;
			if (handler != null)
				handler (this, e);
		}
		

		protected virtual void OnDisappeared (CardEventArgs e)
		{
			var handler = this.Disappeared;
			if (handler != null)
				handler (this, e);
		}

		private void OnTurnStateComplete ()
		{
			OnTurned (new CardEventArgs (this));
		}

		private void OnReturnStateComplete ()
		{
			OnReturned (new CardEventArgs (this));
		}

		private void OnDisapperedStateComplete ()
		{
			OnDisappeared (new CardEventArgs (this));
		}

		private void TapGestureTapped (object sender, System.EventArgs e)
		{
			if (!model.Opened)
				OnTapped (new CardEventArgs (this));	
		}

		public void Turn ()
		{
			animator.SetTrigger (turnTrigger);
		}

		public void Return ()
		{
			animator.SetTrigger (returnTrigger);
		}

		public void Disappear ()
		{
			animator.SetTrigger (disappearTrigger);
		}

		public CardModel Model {
			get {
				return this.model;
			}
			set {
				model = value;
				view.SetModel (model);
				animator.SetTrigger (initialTrigger);
			}
		}

		public event EventHandler<CardEventArgs> Tapped; 
		public event EventHandler<CardEventArgs> Turned;
		public event EventHandler<CardEventArgs> Returned;
		public event EventHandler<CardEventArgs> Disappeared;
	}
}