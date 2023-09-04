using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;
    [SerializeField] private Bar _healthBar;

    public void GetDamage(float damage)
    {
        if (_health - damage >= _minHealth)
        {
            _health -= damage;
            _healthBar.ChangeValue(-damage);
        }
        else
            _health = _minHealth;
    }

    public void GetHeal(float heal)
    {
        if (_health + heal <= _maxHealth)
        {
            _health += heal;
            _healthBar.ChangeValue(heal);
        }
        else
            _health = _maxHealth;
    }
}
