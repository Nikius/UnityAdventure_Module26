using System.Collections;
using UnityEngine;

namespace Project.Develop
{
    public class Platform: MonoBehaviour
    {
        private const float TimeToDestroy = 3f;
        
        [SerializeField] private TouchingChecker _touchingChecker;
        [SerializeField] private float _timeToFall;
        [SerializeField] private Animator _animator;

        private PlatformView _view;
        
        private bool _isActivated;

        private void Awake()
        {
            _view = new PlatformView(_animator);
        }

        private void Update()
        {
            if (_isActivated)
                return;

            if (_touchingChecker.IsTouches())
            {
                _isActivated = true;
                StartCoroutine(Fall());
            }
        }

        private IEnumerator Fall()
        {
            yield return new WaitForSeconds(_timeToFall);
            
            _view.OnFall();
            
            Destroy(gameObject, TimeToDestroy);
        }
    }
}