using System;
using System.Collections;
using JetBrains.Annotations;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace _project.Scripts.Enigmas.PhEnigma
{
    public class Bottle : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _targetActivePosition;
        [SerializeField]
        private Vector3 _targetActiveRotation;
        private Transform _startPosition;

        [SerializeField, Foldout("Debug display")] 
        private bool _showTargetDisplay;
        [SerializeField, Foldout("Debug display")]
        private GameObject _activeDisplay;

        private bool _isActive;
        
        [SerializeField, Range(0f, 2f)]
        private float _spawnInterval;
        private bool _canSpawn = true;

        [SerializeField] 
        private GameObject _dropletPrefab;
        
        private void Awake()
        {
            Destroy(_activeDisplay);
        }

        private void OnMouseDown()
        {
            _isActive = !_isActive;
            transform.position = _isActive ? transform.InverseTransformPoint(_targetActivePosition) : _startPosition.position;
            transform.rotation = _isActive ? Quaternion.Euler(_targetActiveRotation) : _startPosition.rotation;
        }

        private void OnEnable()
        {
            InputManager.SpacePressed += OnSpacePressed;
        }
        
        private void OnDisable()
        {
            InputManager.SpacePressed -= OnSpacePressed;
        }
        
        private void OnSpacePressed(InputAction.CallbackContext obj)
        {
            if (obj.performed && _isActive && _canSpawn)
            {
                _canSpawn = false;
                SpawnDroplet();
                StartCoroutine(DoSpawnCooldown());
            }
        }

        private void SpawnDroplet()
        {
            Instantiate(_dropletPrefab, transform.position, Quaternion.identity);
        }

        private IEnumerator DoSpawnCooldown()
        {
            yield return new WaitForSeconds(_spawnInterval);
            _canSpawn = true;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _activeDisplay.gameObject.SetActive(_showTargetDisplay);
            _activeDisplay.transform.position = transform.InverseTransformPoint(_targetActivePosition);
            _activeDisplay.transform.rotation = Quaternion.Euler(_targetActiveRotation);
        }
#endif
    }
}