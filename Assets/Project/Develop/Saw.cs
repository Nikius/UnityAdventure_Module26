using System.Collections.Generic;
using UnityEngine;

namespace Project.Develop
{
    public class Saw: MonoBehaviour
    {
        private const float MoveDeadZone = .1f;
        
        [SerializeField] private float _speed;
        [SerializeField] private List<Transform> _patrolPoints;

        private readonly Queue<Vector2> _patrolTargetsQueue = new();
        private Vector2 _currentTarget;

        private void Start()
        {
            foreach (var patrolPoint in _patrolPoints)
                _patrolTargetsQueue.Enqueue(patrolPoint.position);
            
            SetNextTarget();
        }

        private void Update()
        {
            if (Vector2.Distance(transform.position, _currentTarget) <= MoveDeadZone)
                SetNextTarget();

            Vector2 direction = _currentTarget - new Vector2(transform.position.x, transform.position.y);
            
            transform.Translate(direction.normalized * (_speed * Time.deltaTime), Space.World);
        }

        private void SetNextTarget()
        {
            Vector2 patrolTarget = _patrolTargetsQueue.Dequeue();
            _currentTarget = patrolTarget;
            _patrolTargetsQueue.Enqueue(patrolTarget);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Character character = other.GetComponent<Character>();
        
            if (character != null)
                character.OnDead();
        }
    }
}