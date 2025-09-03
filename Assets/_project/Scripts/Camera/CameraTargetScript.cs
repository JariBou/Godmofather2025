using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace _project.Scripts.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera), typeof(Animator))]
    public class CameraTargetScript : MonoBehaviour
    {
        private static readonly int DoShake = Animator.StringToHash("DoShake");

        [SerializeField]
        private Vector2 _targetPosition;
        
        private Vector3 TargetPositionV3 => new(_targetPosition.x, _targetPosition.y, transform.position.z);
        private Vector3 _startPosition;

        [SerializeField]
        private AnimationCurve _moveCurve;
        
        [SerializeField, Range(0f, 5f)]
        private float _speed;
        
        [SerializeField]
        private List<Transform> _targets = new();
        private int _targetIndex;

        private int TargetIndex
        {
            get => _targetIndex;
            set
            {
                _targetIndex = Mathf.Clamp(value, 0, _targets.Count-1);
                _targetPosition = _targets[_targetIndex].position;
                _startPosition = transform.position;
                ResetTimer();
            }
        }

        [ShowNonSerializedField]
        private float _internalTimer = 10f;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _targetPosition = _targets[TargetIndex].position;
        }

        private void Update()
        {
            if (_internalTimer < 1f)
            {
                _internalTimer += Time.deltaTime * _speed;
            }
            transform.position = Vector3.Lerp(_startPosition, TargetPositionV3, _moveCurve.Evaluate(_internalTimer));

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (_internalTimer >= (((TargetIndex + 1) % _targets.Count == 0) ? .7f : .2f))
                {
                    GotoNextTarget();
                }
            } else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (_internalTimer >= (((TargetIndex - 1) < 0) ? .7f : .2f))
                {
                    GotoPreviousTarget();
                }                
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

        public void GotoNextTarget()
        {
            if (TargetIndex == _targets.Count - 1)
            {
                _animator.SetTrigger(DoShake);
                return;
            }
            ++TargetIndex;
        }

        public void GotoPreviousTarget()
        {
            if (TargetIndex == 0)
            {
                _animator.SetTrigger(DoShake);
                return;
            }
            --TargetIndex;
        }
    }
}