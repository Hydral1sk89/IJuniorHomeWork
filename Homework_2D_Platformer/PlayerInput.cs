using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerAttack _playerAttack;

    private float _right = 1;
    private float _left = -1;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _playerMovement.Run(_right);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _playerMovement.Run(_left);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _playerMovement.Jump();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            _playerAttack.Attack();
        }
    }
}