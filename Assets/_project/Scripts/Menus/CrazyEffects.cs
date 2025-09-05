using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CrazyEffects : MonoBehaviour
{
    [SerializeField] private Vector2 _scaleCoef = new Vector2(1, 1.2f);
    [SerializeField] private float _loopSpeed = 0.5f;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private TextMeshProUGUI _tmp;
    private float _timer;
    private int _hsvTest;
    private bool _hasLooped = false;

    private void Start()
    {
        _timer = 0f;
        _hsvTest = 0;
    }

    void Update()
    {
        float _time = _timer / _loopSpeed;
        float _curveValue = _curve.Evaluate(_time);
        transform.localScale = new Vector3(Mathf.Lerp(_scaleCoef.x, _scaleCoef.y, _curveValue), Mathf.Lerp(_scaleCoef.x, _scaleCoef.y, _curveValue), Mathf.Lerp(_scaleCoef.x, _scaleCoef.y, _curveValue));
        if (!_hasLooped)
        {
            _timer += Time.deltaTime;
        }
        else if (_hasLooped)
        {
            _timer -= Time.deltaTime;
        }
        if (_timer > _loopSpeed)
        {
            _hasLooped = true;
        }
        else if (_timer < 0f)
        {
            _hasLooped = false;
        }

        _tmp.color = Color.HSVToRGB((float)_hsvTest/360,1,1);
        if (_hsvTest < 360)
            _hsvTest += 1;
        else
            _hsvTest = 0;
    }
}
