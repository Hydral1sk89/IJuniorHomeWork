using UnityEngine;

public class BirdShoot : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _reloadTime;

    private float _elapsedTime;
    private bool _canShoot;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _reloadTime)
            _canShoot = true;

        if (Input.GetMouseButtonDown(1))
        {
            if (_canShoot)
            {
                Shoot();
                _elapsedTime = 0;
                _canShoot = false;
            }
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        bullet.Init(transform.right, transform.localRotation);
    }
}
