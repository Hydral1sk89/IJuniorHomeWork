using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;
    [SerializeField] private UnityEvent _damaged;
    [SerializeField] private UnityEvent _healed;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _damaged?.Invoke();

        if (_health - damage < _minHealth)
            _health = _minHealth;
    }

    public void TakeHeal(float heal)
    {
        _health += heal;
        _healed?.Invoke();

        if (_health + heal > _maxHealth)
        {
            _health = _maxHealth;
        }
    }
}
