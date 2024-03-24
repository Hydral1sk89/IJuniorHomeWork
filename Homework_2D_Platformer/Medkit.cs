using UnityEngine;
using UnityEngine.Events;

public class Medkit : MonoBehaviour
{
    [SerializeField] private int _healthPower;

    public int HealthPower => _healthPower;

    public event UnityAction MedkitTaken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerAnimation _))
        {
            MedkitTaken?.Invoke();
            Destroy(gameObject);
        }
    }
}