using System;
using UnityEngine;

namespace Project.Develop
{
    public class PlatformView: MonoBehaviour
    {
        private readonly int _isFallingKey = Animator.StringToHash("IsFalling");
        
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void OnFall()
        {
            _animator.SetBool(_isFallingKey, true);
        }
    }
}