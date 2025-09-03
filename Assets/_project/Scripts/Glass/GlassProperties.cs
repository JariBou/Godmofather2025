using System;
using UnityEngine;

namespace _project.Scripts.Glass
{
    public class GlassProperties : MonoBehaviour
    {
        [SerializeField] private PHData _phData;
        [SerializeField] private PurityData _purity;
        [SerializeField] private float _temperature;



        public float GetScore()
        {
            return _phData.GetScore() + _purity.GetScore();
        }

        [Serializable]
        public class PHData
        {
            [SerializeField] private float _current; //current Ph between 0 and 14
            public float Current
            {
                get { return _current; }
                set { _current = Mathf.Clamp(value, 0, 14); }
            }
            public float Target = 7; //target Ph
            public float Delta = 0.4f;//level of leniency
            [SerializeField] private float _scoreMultiplier; //score  multiplier
            public float ScoreMultiplier => _scoreMultiplier;

            public float GetScore() => ScoreMultiplier;
        }

        [Serializable]
        public class PurityData
        {
            public float Current = 0f; //current amount of purity
            public float Target = 100f; //target amount of purity
            public float Delta = 5f; //level of leniency
            [SerializeField] private float _scoreMultiplier; //score  multiplier
            public float ScoreMultiplier => _scoreMultiplier;

            public float GetScore() => ScoreMultiplier;
        }
    }
}