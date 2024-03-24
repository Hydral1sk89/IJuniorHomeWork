using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _playerHealth = 3;
    [SerializeField] private int _maxHealth = 3;

    private PlayerAnimation _playerAnimation;

    private void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Medkit>(out Medkit medkit))
        {
            TakeHealth(medkit.HealthPower);
        }
    }

    public void TakeDamage(int damage)
    {
        if (_playerHealth - damage <= 0)
        {
            _playerAnimation.Dead();
        }
        _playerHealth -= damage;
    }

    private void TakeHealth(int health)
    {
        if (_playerHealth + health > _maxHealth)
        {
            _playerHealth = _maxHealth;
        }
        else _playerHealth += health;
    }
}