using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _playerHealth = 3;
    [SerializeField] private Medkit _medkit;

    private PlayerAnimation _playerAnimation;

    private void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Medkit>(out Medkit medkit))
        {
            GetHealth(medkit.HealthPower);
        }
    }

    public void TakeDamage(int damage)
    {
        if(_playerHealth - damage <= 0)
        {
            _playerAnimation.Dead();
        }
        _playerHealth -= damage;
    }

    private void GetHealth(int health)
    {
        if (_playerHealth + health > 3)
        {
            _playerHealth = 3;
        }
        else _playerHealth += health;
    }
}