using UnityEngine;

namespace _Main.Scripts
{
    public class AnimationHandler : MonoBehaviour
    {
        public Animator animator;

        public void PlayAnimation(string animationName)
        {
            animator.SetBool(animationName, true);
        }
        
        public void StopAnimation(string animationName)
        {
            animator.SetBool(animationName, false);
        }
    }
}