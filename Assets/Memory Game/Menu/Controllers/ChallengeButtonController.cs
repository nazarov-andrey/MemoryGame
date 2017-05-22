using MemoryGame.Common.Controllers;
using Zenject;
using MemoryGame.Game.Gameplay;

namespace MemoryGame.Menu.Controllers {
	public class ChallengeButtonController : SwitchSceneButtonController
	{
		protected override void ProvideExtraBindings (DiContainer container)
		{
			container
				.Bind (typeof (TimeUpLossChecker), typeof (IInitializable))
				.To<TimeUpLossChecker> ()
				.AsSingle ();
		}

		protected override string SceneToLoad {
			get {
				return GameSceneName;
			}
		}	

		protected override string SceneToUnload {
			get {
				return MenuSceneName;
			}
		}
	}
}