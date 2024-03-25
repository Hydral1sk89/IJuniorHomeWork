using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    public void Jump()
    {
        transform.Translate(0, _jumpForce * Time.deltaTime, 0);
    }

    public void Run(float direction)
    {
        transform.Translate(_speed * Time.deltaTime * direction, 0, 0);
    }
}