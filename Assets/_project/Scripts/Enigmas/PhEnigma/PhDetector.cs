using System.Collections;
using _project.Scripts.Enigmas.PhEnigma.Interfaces;
using UnityEngine;

namespace _project.Scripts.Enigmas.PhEnigma
{
    public class PhDetector : MonoBehaviour
    {
        [SerializeField] 
        private float _completionTime = 2f;
        private IPhDetectorSpawner _phDetectorSpawner;


        public void Config(IPhDetectorSpawner detectorSpawner)
        {
            _phDetectorSpawner = detectorSpawner;
        }

        private IEnumerator DoPhDetection()
        {
            yield return new WaitForSeconds(_completionTime);
            transform.position = _phDetectorSpawner.GetOverPosition();
            transform.rotation = Quaternion.Euler(_phDetectorSpawner.GetOverRotation());
            _phDetectorSpawner.Release();
        }

        public void Debut()
        {
            StartCoroutine(DoPhDetection());
        }
    }
}