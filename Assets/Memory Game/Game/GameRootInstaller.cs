using Zenject;
using MemoryGame.Game.Models;
using System;
using UnityEngine;
using System.Collections.Generic;
using MemoryGame.Game.Controllers;

namespace MemoryGame.Game.Gameplay {
	public class GameRootInstaller : MonoInstaller
	{
		public override void InstallBindings ()
		{
			Container
				.Bind (typeof (IGridModel), typeof (GridModelWrapper))
				.To<GridModelWrapper> ()
				.AsSingle ();

			Container
				.BindFactory<IGridModel, GridModelFactory> ()
				.To<PredefinedGridModel> ();

			Container
				.Bind<GridController> ()
				.AsSingle ()
				.NonLazy ();

			Container
				.Bind (typeof (Game), typeof (IInitializable))
				.To<Game> ()
				.AsSingle ()
				.NonLazy ();

			Container.BindInitializableExecutionOrder<Game> (100);

			Container.DeclareSignal<LockInteractionSignal> ();
			Container.DeclareSignal<UnlockInteractionSignal> ();
			Container
				.Bind (typeof (InteractionManager), typeof (IInitializable))
				.To<InteractionManager> ()
				.AsSingle ();

			Container.DeclareSignal<TurnSignal> ();
			Container.DeclareSignal<VictorySignal> ();
			Container.DeclareSignal<LossSignal> ();
			Container.DeclareSignal<GameStartSignal> ();
			Container
				.Bind (typeof (VictoryChecker), typeof (IInitializable))
				.To<VictoryChecker> ()
				.AsSingle ();

			Container.BindMemoryPool<DelayedAction, DelayedAction.Pool> ();

			List<Sprite> sprites = new List<Sprite> (Resources.LoadAll<Sprite> ("Sprites"));
			Container.BindInstance (sprites);
		}
	}
}