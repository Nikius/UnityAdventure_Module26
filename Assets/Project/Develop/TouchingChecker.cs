using UnityEngine;

namespace Project.Develop
{
    public class TouchingChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private CapsuleCollider2D _collider;
        [SerializeField] private Vector2 _direction;
        
        [SerializeField] private float _distanceToCheck;
        
        public bool IsTouches()
            => Physics2D.CapsuleCast(
                    _collider.bounds.center,
                    _collider.size,
                    _collider.direction,
                    0,
                    _direction,
                    _distanceToCheck,
                    _layerMask
                ).collider != null;
    }
}
