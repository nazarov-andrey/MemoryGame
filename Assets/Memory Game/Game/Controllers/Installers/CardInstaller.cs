using Zenject;
using UnityEngine;
using TouchScript.Gestures;

namespace MemoryGame.Game.Controllers {
	public class CardInstaller : MonoInstaller
	{
		public override void InstallBindings ()
		{
			Container
				.Bind<Animator> ()
				.FromComponentInHierarchy ();

			Container
				.Bind<CardView> ()
				.AsSingle ();

			Container
				.Bind<CardController> ()
				.FromNewComponentOn (gameObject)
				.AsSingle ();

			Container
				.Bind<TapGesture> ()
				.FromComponentInHierarchy ()
				.AsSingle ();
		}
	}
}