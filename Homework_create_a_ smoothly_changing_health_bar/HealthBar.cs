using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _health;
    [SerializeField] private float _changeSpeed;
    [SerializeField] private float _damagePower;
    [SerializeField] private float _healPower;

    private float _targetHealth;

    private void Start()
    {
        _slider.maxValue = _health;
        _slider.value = _health;
        _targetHealth = _health;
    }

    void Update()
    {
        _health = Mathf.MoveTowards(_health, _targetHealth, _changeSpeed * Time.deltaTime);
        _slider.value = _health;
    }

    public void Damage()
    {
        if (_targetHealth > 0)
        {
            if (_health - _damagePower >= 0)
                _targetHealth -= _damagePower;
            else
                _targetHealth = 0;
        }
    }

    public void Heal()
    {
        if (_targetHealth < _slider.maxValue)
        {
            if (_health + _healPower > _slider.maxValue)
                _targetHealth = _slider.maxValue;
            else
                _targetHealth += _healPower;
        }
    }

    public void ChangeValue(float target)
    {
        if ((_health + target) >= _slider.minValue && (_health + target) <= _slider.maxValue)
            _targetHealth = _targetHealth + target;
        else if (target > _slider.minValue)
            _targetHealth = _slider.maxValue;
        else
            _targetHealth = _slider.minValue;
    }
}
