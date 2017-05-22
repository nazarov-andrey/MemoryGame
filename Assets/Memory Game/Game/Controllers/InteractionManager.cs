using Zenject;
using TouchScript.Layers;

namespace MemoryGame.Game.Controllers {
	public class InteractionManager : IInitializable
	{
		private LockInteractionSignal lockInteractionSignal;
		private UnlockInteractionSignal unlockInteractionSignal;
		private UILayer UILayer; 

		public InteractionManager (
			LockInteractionSignal lockInteractionSignal,
			UnlockInteractionSignal unlockInteractionSignal,
			UILayer UILayer)
		{
			this.lockInteractionSignal = lockInteractionSignal;
			this.unlockInteractionSignal = unlockInteractionSignal;
			this.UILayer = UILayer;
		}

		public void Initialize ()
		{
			lockInteractionSignal += LockInteractionSignal;
			unlockInteractionSignal += UnlockInteractionSignal;
		}

		private void LockInteractionSignal ()
		{
			UILayer.enabled = false;
		}

		private void UnlockInteractionSignal ()
		{
			UILayer.enabled = true;
		}
	}
}