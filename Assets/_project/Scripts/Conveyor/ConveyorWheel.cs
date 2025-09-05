using UnityEngine;

namespace _project.Scripts.Conveyor
{
    public class ConveyorWheel : MonoBehaviour
    {
        [SerializeField]
        private float _baseRotationSpeed;
        private float _speed;
        public void UpdateSpeed(float conveyorSpeed)
        {
            _speed = conveyorSpeed;
        }

        private void Update()
        {
            transform.Rotate(Vector3.back, _baseRotationSpeed * _speed * Time.deltaTime);
        }
    }
}