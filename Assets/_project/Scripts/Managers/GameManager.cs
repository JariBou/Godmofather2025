using System;
using UnityEngine;

namespace _project.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        public static event Action<bool> GameEnded;

        public bool IsGameRunning { get; private set; } = true;
        [SerializeField, Range(0f, 10000f)] 
        private float _gameDuration = 360;

        [SerializeField] 
        private int _lives = 3;
        
        private float _timer;

        private void Awake()
        {
            Instance ??= this;
        }

        private void Update()
        {
            if (!IsGameRunning) return;
            _timer += Time.deltaTime;
            if (_timer >= _gameDuration)
            {
                EndGame(true);
            }
        }

        private void EndGame(bool won)
        {
            IsGameRunning = false;
            GameEnded?.Invoke(won);
        }

        public static void RemoveLife()
        {
            // Instance._lives--;
            // if (Instance._lives <= 0)
            // {
            //     Instance.EndGame(false);
            // }
        }
    }
}