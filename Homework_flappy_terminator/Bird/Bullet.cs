using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction;
    private Quaternion _rotation;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
        transform.localRotation = _rotation;
    }

    public void Init(Vector3 direction, Quaternion rotation)
    {
        _direction = direction;
        _rotation = rotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            Destroy(gameObject);
        }
    }
}
