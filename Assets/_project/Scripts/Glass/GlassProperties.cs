using System;
using UnityEngine;

namespace NaughtyAttributes
{
    public class GlassProperties : MonoBehaviour
    {
        [SerializeField] private PHData phData;
        [SerializeField] private Purity purity;
        [SerializeField] private float temperature;



        public float GetScore()
        {
            return phData.GetScore() + purity.GetScore();
        }

        [Serializable]
        public class PHData
        {
            private float current; //current Ph between 0 and 14
            public float Current
            {
                get { return current; }
                set { current = Mathf.Clamp(value, 0, 14); }
            }
            public float target = 7; //target Ph
            public float delta = 0.4f; //level of leniency
            public float scoreMultiplier; //score multiplier

            public float GetScore()
            {
                return scoreMultiplier;
            }
        }

        [Serializable]
        public class Purity
        {
            public float current = 0f; //current amount of purity
            public float target = 100f; //target amount of purity
            public float delta; //level of leniency
            public float scoreMultiplier; //score  multiplier

            public float GetScore()
            {
                return scoreMultiplier;
            }
        }
    }
}