using System;
using UnityEngine;

namespace _project.Scripts.Glass
{
    public class Glass : MonoBehaviour
    {
        public enum Type {
            NONE,
            RED,
            GREEN,
            BLUE
        }
        private SpriteRenderer _spriteRenderer;

        [SerializeField] private Type _type;
        
        public Type GetGlassType() => _type;

        private void Awake()
        {
            TryGetComponent(out _spriteRenderer);
        }

        private void Start()
        {
            _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _spriteRenderer.color.a);
            _type = (Type)UnityEngine.Random.Range(1, Enum.GetNames(typeof(Type)).Length);
            UpdateColor();
        }

        private void UpdateColor()
        {
            if (_type == Type.RED)
            {
                _spriteRenderer.color = Color.red;
            }
            else if (_type == Type.GREEN)
            {
                _spriteRenderer.color = Color.green;
            }
            else if (_type == Type.BLUE)
            {
                _spriteRenderer.color = Color.blue;
            }
            else
            {
                _spriteRenderer.color = Color.white;
            }
        }
    }

}