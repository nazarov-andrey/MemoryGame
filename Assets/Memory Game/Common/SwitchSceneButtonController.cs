using UnityEngine;
using Zenject;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MemoryGame.Common.Controllers {
	public abstract class SwitchSceneButtonController : MonoBehaviour
	{
		private string gameSceneName;
		private string menuSceneName;
		private ZenjectSceneLoader zenjectSceneLoader;

		[Inject]
		private void Inject (
			[Inject (Id = SceneIds.Game)] string gameSceneName,
			[Inject (Id = SceneIds.Menu)] string menuSceneName,
			ZenjectSceneLoader zenjectSceneLoader)
		{
			this.gameSceneName = gameSceneName;
			this.menuSceneName = menuSceneName;
			this.zenjectSceneLoader = zenjectSceneLoader;
		}

		public void OnButtonClick ()
		{
			StartCoroutine (LoadScene ());
		}

		protected abstract void ProvideExtraBindings (DiContainer container);

		public IEnumerator LoadScene ()
		{
			AsyncOperation asyncOperation = zenjectSceneLoader.LoadSceneAsync (
                SceneToLoad,
                UnityEngine.SceneManagement.LoadSceneMode.Additive,
                ProvideExtraBindings);

			yield return asyncOperation;

			SceneManager.UnloadSceneAsync (SceneToUnload);
		}

		protected string GameSceneName {
			get {
				return this.gameSceneName;
			}
		}

		protected string MenuSceneName {
			get {
				return this.menuSceneName;
			}
		}

		protected abstract string SceneToLoad { get; }
		protected abstract string SceneToUnload { get; }
	}
}