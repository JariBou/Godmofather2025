using System;
using UnityEngine;

namespace _project.Scripts.Glass
{
    public class GlassProperties : MonoBehaviour
    {
        private enum TYPE {
            NONE,
            RED,
            GREEN,
            BLUE
        }
        private SpriteRenderer _spriteRenderer;

        [SerializeField] private TYPE _type;

        private void Awake()
        {
            TryGetComponent(out _spriteRenderer);
        }

        private void Start()
        {
            _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _spriteRenderer.color.a);
            _type = (TYPE)UnityEngine.Random.Range(1, Enum.GetNames(typeof(TYPE)).Length);
            UpdateColor();
        }

        private void UpdateColor()
        {
            if (_type == TYPE.RED)
            {
                _spriteRenderer.color = Color.red;
            }
            else if (_type == TYPE.GREEN)
            {
                _spriteRenderer.color = Color.green;
            }
            else if (_type == TYPE.BLUE)
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