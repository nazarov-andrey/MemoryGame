using Zenject;
using UnityEngine;
using MemoryGame.Common;

namespace MemoryGame.Launcher {
	public class LauncherEntryPoint : IInitializable, ITickable
	{
		private ZenjectSceneLoader zenjectSceneLoader;
		private string menuSceneName;
		private TickableManager tickableManager;
		private AsyncOperation asyncOperation;

		private LauncherEntryPoint (
			ZenjectSceneLoader zenjectSceneLoader,
			[Inject (Id = SceneIds.Menu)] string menuSceneName,
			TickableManager tickableManager)
		{
			this.zenjectSceneLoader = zenjectSceneLoader;
			this.menuSceneName = menuSceneName;
			this.tickableManager = tickableManager;
		}

		public void Initialize ()
		{
			asyncOperation = zenjectSceneLoader.LoadSceneAsync (
				menuSceneName,
				UnityEngine.SceneManagement.LoadSceneMode.Additive);
		}

		public void Tick ()
		{
			if (!asyncOperation.isDone)
				return;

			tickableManager.Remove (this);
		}
	}
}