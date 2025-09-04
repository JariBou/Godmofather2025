using System;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _project.Scripts
{
    public class GlassSpawner : MonoBehaviour
    {
        [Serializable]
        public class Spawner
        {
            [SerializeField]
            private Transform _spawnPoint;
            
            private float _spawnCooldown;
            private float _timer;
            private GameObject _prefab;
            private float _evolveValue;
            private float _randomSpawnDeltaTime;
            private float _selectedRandomSpawnDeltaTime = 0f;


            private void DoSpawn()
            {
                Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
                _selectedRandomSpawnDeltaTime = Random.Range(-_randomSpawnDeltaTime, _randomSpawnDeltaTime);
            }
            
            public void Update(float deltaTime)
            {
                _timer += deltaTime * _evolveValue;
                if (_timer >= _spawnCooldown + _selectedRandomSpawnDeltaTime)
                {
                    _timer = 0f;
                    DoSpawn();
                }
            }
            
            public void Config(GameObject glassPrefab, float spawnCooldown, float randomSpawnDeltaTime)
            {
                _prefab = glassPrefab;
                _spawnCooldown = spawnCooldown;
                _randomSpawnDeltaTime = randomSpawnDeltaTime;
            }

            public void UpdateEvolve(float multiplierValue, float randomSpawnDeltaTime)
            {
                _evolveValue = 1 + multiplierValue;
                _randomSpawnDeltaTime = randomSpawnDeltaTime;
            }
        }
        
        [SerializeField]
        private GameObject _glassPrefab;
        
        [SerializeField]
        private Spawner[] _spawners = new Spawner[2];

        [SerializeField]
        private bool _isActive;

        [SerializeField]
        private AnimationCurve _evolveCurve;
        [SerializeField]
        private float _maxEvolveTime;
        [SerializeField]
        private float _evolveMultiplier = 2f;
        [ShowNonSerializedField]
        private float _evolveTimer;

        [SerializeField, Range(0.1f, 1f)] 
        private float _randomSpawnDeltaTimeMultiplier = .1f;
        [SerializeField]
        private AnimationCurve _randomSpawnDeltaTimeCurve;
        [SerializeField, Range(1f, 10f)] 
        private float _spawnCooldown = 1f;

        public void Activate()
        {
            _isActive = true;
        }

        private void Awake()
        {
            foreach (Spawner spawner in _spawners)
            {
                spawner.Config(_glassPrefab, _spawnCooldown, GetRandomSpawnDeltaTime());
            }
        }

        private float GetRandomSpawnDeltaTime()
        {
            return (1 - _randomSpawnDeltaTimeCurve.Evaluate(_evolveTimer / _maxEvolveTime))  * _randomSpawnDeltaTimeMultiplier;
        }

        private void Update()
        {
            if (!_isActive) return;

            foreach (Spawner spawner in _spawners)
            {
                spawner.Update(Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (!_isActive || _evolveTimer >= _maxEvolveTime * 1.2f) return;
            
            _evolveTimer += Time.fixedDeltaTime;
            float multiplierValue = _evolveCurve.Evaluate(_evolveTimer / _maxEvolveTime) * Math.Max(_evolveMultiplier - 1f, 1f);
            
            foreach (Spawner spawner in _spawners)
            {
                spawner.UpdateEvolve(multiplierValue, GetRandomSpawnDeltaTime());
            }
        }
    }

    
}