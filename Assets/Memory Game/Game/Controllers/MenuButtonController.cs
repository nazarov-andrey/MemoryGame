using UnityEngine;
using MemoryGame.Common.Controllers;

namespace MemoryGame.Game.Controllers {
	public class MenuButtonController : SwitchSceneButtonController
	{
		protected override void ProvideExtraBindings (Zenject.DiContainer container)
		{
		}

		protected override string SceneToLoad {
			get {
				return MenuSceneName;
			}
		}

		protected override string SceneToUnload {
			get {
				return GameSceneName;
			}
		}
	}
}