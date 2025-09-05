using _project.Scripts.Enigmas.PhEnigma.Interfaces;
using JetBrains.Annotations;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace _project.Scripts.Enigmas.PhEnigma
{
    public class PhDetectorSpawner : MonoBehaviour, IPhDetectorSpawner
    {
        [FormerlySerializedAs("_targetPosition")] [SerializeField]
        private Vector3 _targetInGlassPosition;
        [SerializeField]
        private Vector3 _targetOverPosition;
        [SerializeField]
        private Vector3 _targetOverRotation;
        public Vector3 GetOverPosition() => _targetOverPosition;
        public Vector3 GetOverRotation() => _targetOverRotation;

        //[SerializeField] 
        //private float _completionTime = 2f;

        [SerializeField, Foldout("Display debug")] 
        private bool _showTargetDisplay;
        [FormerlySerializedAs("_targetDisplay")] [SerializeField, Foldout("Display debug")]
        private GameObject _targetInGlassDisplay;
        [SerializeField, Foldout("Display debug")]
        private GameObject _targetOverDisplay;
        
        [SerializeField]
        private GameObject _phDetectorPrefab;
        
        [CanBeNull] 
        private PhDetector _phDetectorInstance;

        private bool _canSpawn = true;


        private void Awake()
        {
            Destroy(_targetInGlassDisplay);
            Destroy(_targetOverDisplay);
        }

        private void OnMouseDown()
        {
            if (_canSpawn)
            {
                Destroy(_phDetectorInstance?.gameObject);
                Reserve();
                _phDetectorInstance = Instantiate(_phDetectorPrefab, _targetInGlassPosition, Quaternion.identity).GetComponent<PhDetector>();
                _phDetectorInstance!.Config(this);
                _phDetectorInstance!.Debut();
            }
        }
        
        public void Release()
        {
            _canSpawn = true;
        }

        public void Reserve()
        {
            _canSpawn = false;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _targetInGlassDisplay.gameObject.SetActive(_showTargetDisplay);
            _targetInGlassDisplay.transform.position = transform.InverseTransformPoint(_targetInGlassPosition);
            
            _targetOverDisplay.gameObject.SetActive(_showTargetDisplay);
            _targetOverDisplay.transform.position = transform.InverseTransformPoint(GetOverPosition());
            _targetOverDisplay.transform.rotation = Quaternion.Euler(GetOverRotation());
        }
#endif
    }
}