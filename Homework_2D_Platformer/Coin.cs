using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private CoinSpawner _coinSpawner; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _coinSpawner.Spawn();
            Destroy(gameObject);
        }
    }

    public void Init(CoinSpawner coinSpawner)
    {
        _coinSpawner = coinSpawner;
    }
}
