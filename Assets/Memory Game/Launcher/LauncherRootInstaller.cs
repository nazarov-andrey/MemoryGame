using Zenject;
using UnityEngine;
using MemoryGame.Common;
using System;

namespace MemoryGame.Launcher {
	public class LauncherRootInstaller : MonoInstaller
	{
		[SerializeField]
		private string menuSceneName;
		[SerializeField]
		private string gameSceneName;
		[SerializeField]
		private int roundDurationMinutes;
		[SerializeField]
		private int roundDurationSeconds;

		public override void InstallBindings ()
		{
			Container
				.Bind (typeof (LauncherEntryPoint), typeof (ITickable), typeof (IInitializable))
				.To<LauncherEntryPoint> ()
				.AsSingle ();

			Container
				.BindInstance (menuSceneName)
				.WithId (SceneIds.Menu);

			Container
				.BindInstance (gameSceneName)
				.WithId (SceneIds.Game);

			Container
				.BindInstance (new TimeSpan (0, roundDurationMinutes, roundDurationSeconds));
		}
	}
}