using Zenject;
using UnityEngine;

namespace MemoryGame.Game.Controllers {
	public class TimerInstaller : MonoInstaller<TimerInstaller>
	{
		[SerializeField]
		private GameObject timerPrefab;

		public override void InstallBindings ()
		{
			Container
				.Bind<TimerController> ()
				.FromSubContainerResolve ()
				.ByNewPrefab (timerPrefab)
				.UnderTransform (transform)
				.AsSingle ();
		}
	}
}