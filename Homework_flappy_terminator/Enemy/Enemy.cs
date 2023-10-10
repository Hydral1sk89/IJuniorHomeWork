using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyBullet _enemyBullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _delay;

    private Coroutine _rechargeCoroutine;
    private List<EnemyBullet> _bullets = new List<EnemyBullet>();

    public event UnityAction Died;

    private void OnDisable()
    {
        if (_rechargeCoroutine != null)
            StopCoroutine(_rechargeCoroutine);
    }

    public void StartShooting()
    {
        _rechargeCoroutine = StartCoroutine(Shoot());
    }

    public void Die()
    {
        Died?.Invoke();
        gameObject.SetActive(false);
    }

    public void ResetBullets()
    {
        foreach (var bullet in _bullets)
        {
            if (bullet != null)
                Destroy(bullet.gameObject);
        }

        _bullets.Clear();
    }

    private IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            var bullet = Instantiate(_enemyBullet, _shootPoint.position, Quaternion.identity);
            _bullets.Add(bullet);

            yield return wait;
        }
    }
}
