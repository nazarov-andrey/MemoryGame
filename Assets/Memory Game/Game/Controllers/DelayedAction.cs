using Zenject;
using System;
using UnityEngine;
using System.Collections.Generic;

namespace MemoryGame.Game.Controllers {
	public class DelayedAction : ITickable
	{
		public class Pool : MemoryPool<Action, float, DelayedAction>, ILateTickable
		{
			private TickableManager tickableManager;
			private List<DelayedAction> despawnQueue;

			private Pool (TickableManager tickableManager)
			{
				tickableManager.AddLate (this);
				this.tickableManager = tickableManager;
				this.despawnQueue = new List<DelayedAction> ();
			}

			protected override void OnCreated (DelayedAction item)
			{
				base.OnCreated (item);
				tickableManager.Add (item);
			}

			protected override void Reinitialize (Action action, float delay, DelayedAction item)
			{
				base.Reinitialize (action, delay, item);
				item.Start (action, delay);
			}

			protected override void OnDespawned (DelayedAction item)
			{
				base.OnDespawned (item);
				item.Reset ();
			}

			public void LateTick ()
			{
				foreach (var item in despawnQueue) {
					Despawn (item);
				}

				despawnQueue.Clear ();
			}

			public void QueueForDespawn (DelayedAction item)
			{
				despawnQueue.Add (item);
			}
		}

		private Action action;
		private float startTime;
		private float delay;

		private DelayedAction ()
		{
		}

		private float GetCurrentTime ()
		{
			return Time.realtimeSinceStartup;
		}

		private void Start (Action action, float delay)
		{
			this.action = action;
			this.delay = delay;
			this.startTime = GetCurrentTime ();
		}

		private void Reset ()
		{
			this.action = null;
		}

		public void Tick ()
		{
			if (action == null)
				return;

			if (GetCurrentTime () - startTime >= delay)
				action ();
		}
	}
}