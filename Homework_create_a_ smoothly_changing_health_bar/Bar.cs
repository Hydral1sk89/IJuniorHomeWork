using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _currentValue;
    [SerializeField] private float _changeSpeed;

    private Coroutine _changeValueJob;
    private float _targetValue;

    private void Start()
    {
        _slider.value = _currentValue;
        _targetValue = _currentValue;
    }

    public void ChangeValue(float value)
    {
        _changeValueJob = StartCoroutine(MoveSlider(value));
    }

    private IEnumerator MoveSlider(float value)
    {
        if (_targetValue + value >= _slider.minValue && _targetValue + value <= _slider.maxValue)
            _targetValue += value;

        while (Mathf.Abs(_currentValue - _targetValue) > Mathf.Epsilon)
        {
            _currentValue = Mathf.MoveTowards(_currentValue, _targetValue, _changeSpeed * Time.deltaTime);
            _slider.value = _currentValue;

            yield return null;
        }
    }
}
