using UnityEngine;

namespace Project.Develop
{
    public class PlatformView
    {
        private readonly int _isFallingKey = Animator.StringToHash("IsFalling");
        
        private readonly Animator _animator;

        public PlatformView(Animator animator)
        {
            _animator = animator;
        }

        public void OnFall()
        {
            _animator.SetBool(_isFallingKey, true);
        }
    }
}