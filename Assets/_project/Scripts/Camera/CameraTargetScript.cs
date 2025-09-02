using System.Collections.Generic;
using UnityEngine;

namespace _project.Scripts.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class CameraTargetScript : MonoBehaviour
    {
        [SerializeField]
        private Vector2 _targetPosition;
        private Vector3 TargetPositionV3 => new(_targetPosition.x, _targetPosition.y, transform.position.z);

        [SerializeField]
        private AnimationCurve _moveCurve;
        
        [SerializeField, Range(0f, 1f)]
        private float _speed;
        
        [SerializeField]
        private List<Transform> _testTargets = new();
        private int _testIndex;

        private float _internalTimer = 10f;

        private void Update()
        {
            if (_internalTimer < 1f)
            {
                _internalTimer += Time.deltaTime * _speed;
            }
            transform.position = Vector3.Lerp(transform.position, TargetPositionV3, _moveCurve.Evaluate(_internalTimer));

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _testIndex = (_testIndex + 1) % _testTargets.Count;
                _targetPosition = _testTargets[_testIndex].position;
                ResetTimer();
            } else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _testIndex--;
                if (_testIndex < 0)
                {
                    _testIndex = _testTargets.Count - 1;
                }
                _targetPosition = _testTargets[_testIndex].position;
                ResetTimer();
            }
        }

        public void SetTargetPosition(Vector2 targetPosition)
        {
            _targetPosition = targetPosition;
            ResetTimer();
        }

        private void ResetTimer()
        {
            _internalTimer = 0f;
        }
    }
}