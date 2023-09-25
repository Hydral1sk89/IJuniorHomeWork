using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyBullet _enemyBullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _timeBetweenShot;

    private float _elapsedTime;

    public event UnityAction Died;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if( _elapsedTime > _timeBetweenShot)
        {
            _elapsedTime = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(_enemyBullet.gameObject, _shootPoint.position, Quaternion.identity);
        bullet.SetActive(true);
    }

    public void Die()
    {
        Died?.Invoke();
        gameObject.SetActive(false);
    }
}
