using System.Collections;
using UnityEngine;

public class BirdShoot : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _reloadTime;

    private bool _canShoot = true;

    public void Shoot()
    {
        if (_canShoot)
        {
            var bullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            bullet.Init(transform.right, transform.localRotation);
            _canShoot = false;
            StartCoroutine(DelayBetweenShot(_reloadTime));
        }
    }

    private IEnumerator DelayBetweenShot(float delay)
    {
        var wait = new WaitForSeconds(delay);

        yield return wait;
        _canShoot = true;
    }
}
