using UnityEngine;

namespace MemoryGame.Animations {
	public class AnimationCompleteBehaviour : StateMachineBehaviour
	{
		[SerializeField]
		private string message;
		private bool messageSent;

		 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			messageSent = false;	
		}

		// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
		override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (animator.GetCurrentAnimatorStateInfo (layerIndex).normalizedTime >= 1f && !messageSent) {
				animator.SendMessage (message, SendMessageOptions.DontRequireReceiver);	
				messageSent = true;
			}
		}

		// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
//		override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//		{
//		}

		// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
		//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//
		//}

		// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
		//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//
		//}
	}
}