using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    IEnumerator ShootingWorker()
    {
        bool isWork = true;

        while (isWork)
        {
            var direction = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return new WaitForSeconds(_delay);
        }
    }
}