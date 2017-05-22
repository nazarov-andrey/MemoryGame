using Zenject;
using UnityEngine;
using System.Collections.Generic;

namespace MemoryGame.Game.Controllers {
	public class GridInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject cardPrefab;

		public override void InstallBindings ()
		{
			Container
				.BindMemoryPool<CardController, CardController.Pool> ()
				.FromSubContainerResolve ()
				.ByNewPrefab (cardPrefab)
				.UnderTransform (transform);
		}
	}
}