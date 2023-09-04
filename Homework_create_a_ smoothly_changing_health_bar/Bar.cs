using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _currentValue;
    [SerializeField] private float _changeSpeed;

    private float _targetValue;

    private void Start()
    {
        _slider.value = _currentValue;
        _targetValue = _currentValue;
    }

    void Update()
    {
        _currentValue = Mathf.MoveTowards(_currentValue, _targetValue, _changeSpeed * Time.deltaTime);
        _slider.value = _currentValue;
    }

    public void ChangeValue(float value)
    {
        if ((_currentValue + value) >= _slider.minValue && (_currentValue + value) <= _slider.maxValue)
            _targetValue = _targetValue + value;
        else if (value > _slider.minValue)
            _targetValue = _slider.maxValue;
        else
            _targetValue = _slider.minValue;
    }
}
