using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_delay);
        bool isWork = true;

        while (isWork)
        {
            var direction = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.velocity = direction * _speed;

            yield return wait;
        }
    }
}