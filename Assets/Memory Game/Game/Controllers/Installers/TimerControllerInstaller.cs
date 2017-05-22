using Zenject;
using UnityEngine.UI;
using UnityEngine;

namespace MemoryGame.Game.Controllers {
	public class TimerControllerInstaller : MonoInstaller<TimerControllerInstaller>
	{
		public override void InstallBindings ()
		{
			Container
				.Bind<Text> ()
				.FromComponentInHierarchy ();

			Container
				.Bind<Animator> ()
				.FromComponentInHierarchy ();

			Container
				.BindInstance (5)
				.WhenInjectedInto<TimerController> ();

			Container
				.Bind<TimerController> ()
				.FromNewComponentOn (gameObject)
				.AsSingle ();
		}
	}
}