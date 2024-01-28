using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] private int _healthPower;
    
    private MedkitSpawner _medkitSpawner;

    public int HealthPower => _healthPower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerAnimation>(out PlayerAnimation player))
        {
            _medkitSpawner.Spawn();
            Destroy(gameObject);
        }
    }

    public void Init(MedkitSpawner medkitSpawner)
    {
        _medkitSpawner = medkitSpawner;
    }
}