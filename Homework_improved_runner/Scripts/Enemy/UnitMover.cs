using UnityEngine;

public class UnitMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}
