using System;
using _project.ScripatableObjects.Scripts;
using UnityEngine;

namespace _project.Scripts.Glass
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Glass : MonoBehaviour
    {
        public enum Type {
            NONE,
            RED,
            GREEN,
            BLUE
        }
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private SpriteRenderer _disabledSpriteRenderer;

        [SerializeField] private Type _type;
        [SerializeField] private GlassData _data;
        [SerializeField] private AnimationCurve _moveCurve;
        private bool _shouldMove;
        private Vector3 _targetPosition;
        private Vector3 _startPosition;
        private float _speed;
        private float _timer;

        public Type GetGlassType() => _type;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _disabledSpriteRenderer.enabled = false;
        }

        private void Start()
        {
            _type = (Type)UnityEngine.Random.Range(1, Enum.GetNames(typeof(Type)).Length);
            UpdateSprite();
        }

        private void Update()
        {
            if (_shouldMove)
            {
                _timer += Time.deltaTime * _speed;
                transform.position = Vector3.Lerp(_startPosition, _targetPosition, _moveCurve.Evaluate(_timer));
                if (_timer >= 1.2f)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void UpdateSprite()
        {
            switch (_type)
            {
                case Type.RED:
                    _spriteRenderer.sprite = _data.RedSprite;
                    break;
                case Type.GREEN:
                    _spriteRenderer.sprite = _data.GreenSprite;
                    break;
                case Type.BLUE:
                    _spriteRenderer.sprite = _data.BlueSprite;
                    break;
                case Type.NONE:
                default:
                    _spriteRenderer.color = Color.white;
                    break;
            }
        }

        public void MoveTo(Vector3 transformPosition, float speed)
        {
            _shouldMove = true;
            _targetPosition = transformPosition;
            _speed = speed;
                _startPosition = transform.position;
        }

        public void Disable()
        {
            _disabledSpriteRenderer.enabled = true;
        }
    }

}