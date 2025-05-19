using UnityEngine;

namespace Project.Develop
{
    public class CharacterView: MonoBehaviour
    {
        private readonly int _velocityXKey = Animator.StringToHash("VelocityX");
        private readonly int _velocityYKey = Animator.StringToHash("VelocityY");
        private readonly int _isGroundedKey = Animator.StringToHash("IsGrounded");
        
        [SerializeField] private Character _character;
        [SerializeField] private Animator _animator;

        private void Update()
        {
            _animator.SetFloat(_velocityXKey, Mathf.Abs(_character.Velocity.x));
            _animator.SetFloat(_velocityYKey, _character.Velocity.y);
            _animator.SetBool(_isGroundedKey, _character.IsGrounded());
        }
    }
}