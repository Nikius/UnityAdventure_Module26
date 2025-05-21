using System.Collections;
using UnityEngine;

namespace Project.Develop
{
    public class Platform: MonoBehaviour
    {
        private const float TimeToDestroy = 3f;
        
        [SerializeField] private TouchingChecker _touchingChecker;
        [SerializeField] private float _timeToFall;
        [SerializeField] private PlatformView _platformView;
        
        private bool _isActivated;

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
            
            _platformView.OnFall();
            
            Destroy(gameObject, TimeToDestroy);
        }
    }
}