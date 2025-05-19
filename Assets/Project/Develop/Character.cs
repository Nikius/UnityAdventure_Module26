using System;
using UnityEngine;

namespace Project.Develop
{
    public class Character : MonoBehaviour
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string DeathZoneTag = "DeathZone";

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private TouchingChecker _groundChecker;
        [SerializeField] private TouchingChecker _ceilChecker;
        [SerializeField] private TouchingChecker _leftWallChecker;
        [SerializeField] private TouchingChecker _rightWallChecker;
        
        [SerializeField] private float _speed;
        [SerializeField] private float _yVelocityForJump;
        [SerializeField] private float _freeFallSpeed;
        [SerializeField] private float _slidingDownSpeed;

        private Vector2 _velocity;
        private bool _isJumpPressed;
        private float _fallSpeed;
        
        public Vector2 Velocity => _rigidbody.velocity;

        private Quaternion TurnRight => Quaternion.identity;
        private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

        private void Update()
        {
            float xInput = Input.GetAxis(HorizontalAxisName);
            _isJumpPressed = Input.GetKeyDown(KeyCode.Space);
            
            float horizontalVelocity = xInput * _speed;
            _velocity = new Vector2(horizontalVelocity, _velocity.y);

            HandleGravity();
            HandleCeil();
            HandleJump();

            _rigidbody.velocity = _velocity;
            
            transform.rotation = GetRotationFrom(_velocity);
        }

        public bool IsGrounded() => _groundChecker.IsTouches();

        public bool IsOnWall() => _leftWallChecker.IsTouches() || _rightWallChecker.IsTouches();

        private void HandleGravity()
        {
            if (IsGrounded() && _velocity.y < 0)
            {
                _velocity.y = 0;
                return;
            }

            if (IsOnWall() && _velocity.y < -_slidingDownSpeed)
                _velocity.y = -_slidingDownSpeed;
            else
                _velocity.y -= _freeFallSpeed * Time.deltaTime;
        }

        private void HandleCeil()
        {
            if (_ceilChecker.IsTouches())
                _velocity.y = Mathf.Min(0, _velocity.y);
        }

        private void HandleJump()
        {
            if (_isJumpPressed && (IsGrounded() || IsOnWall()))
                _velocity.y = _yVelocityForJump;
        }

        private Quaternion GetRotationFrom(Vector2 velocity)
        {
            if (velocity.x > 0)
                return TurnRight;
            
            if (velocity.x < 0)
                return TurnLeft;
            
            return transform.rotation;
        }

        public void OnDead()
        {
            Debug.Log("Game Over!");
            gameObject.SetActive(false);
        }
    }
}
