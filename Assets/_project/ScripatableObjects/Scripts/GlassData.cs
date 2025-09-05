using UnityEngine;

namespace _project.ScripatableObjects.Scripts
{
    [CreateAssetMenu(fileName = "GlassData", menuName = "_Game/GlassData")]
    public class GlassData : ScriptableObject
    {
        public Sprite RedSprite;
        public Sprite GreenSprite;
        public Sprite BlueSprite;
    }
}