using UnityEngine;

namespace NaughtyAttributes
{
    public class GlassObject : MonoBehaviour
    {
        public PHData phData;
        public Heat heat;
        public float purity;


        public float GetScore()
        {
            return phData.GetScore() + heat.GetScore();
        }

        public class PHData
        {
            public float current; //between 0 and 14
            public float target = 7; //target Ph
            public float delta = 0.4f; //level of leniency
            public float scoreMultiplier;

            public float GetScore()
            {
                return scoreMultiplier;
            }
        }

        public class Heat
        {
            public float current; //jsp c quoi
            public float target; //
            public float delta; //level of leniency
            public float scoreMultiplier;

            public float GetScore()
            {
                return scoreMultiplier;
            }
        }
    }
}