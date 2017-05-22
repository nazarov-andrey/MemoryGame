using UnityEngine;
using Zenject;
using MemoryGame.Common.Controllers;

namespace MemoryGame {
	public class TrainingButtonController : SwitchSceneButtonController
	{
		protected override void ProvideExtraBindings (DiContainer container)
		{
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