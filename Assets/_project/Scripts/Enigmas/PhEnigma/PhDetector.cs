using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace _project.Scripts.Enigmas.PhEnigma
{
    public class PhDetector : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _targetPosition;
        private Vector3 _startPosition;

        [SerializeField] 
        private float _completionTime = 2f;

        [SerializeField, Foldout("Display debug")] 
        private bool _showTargetDisplay;
        [SerializeField, Foldout("Display debug")]
        private GameObject _targetDisplay;


        private void Awake()
        {
            _startPosition = transform.position;
            Destroy(_targetDisplay);
        }

        private void OnMouseDown()
        {
            transform.position = _targetPosition;
            StartCoroutine(GoBack());
        }

        private IEnumerator GoBack()
        {
            yield return new WaitForSeconds(_completionTime);
            transform.position = _startPosition;
        }

        #if UNITY_EDITOR
        private void OnValidate()
        {
            _targetDisplay.gameObject.SetActive(_showTargetDisplay);
            _targetDisplay.transform.position = _targetPosition;
        }
        #endif
    }
}