using UnityEngine;

[RequireComponent(typeof (Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private const string IsRun = nameof(IsRun);
    private const string IsDead = nameof(IsDead);
    private const string IsAttack = nameof(IsAttack);

    private Vector3 _revertLocalScale;
    private Animator _animator;
    private float _minimalSpeed = 0.1f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _revertLocalScale = transform.localScale;  
    }

    private void FixedUpdate()
    {
       float direction = Input.GetAxis("Horizontal");

        if (Mathf.Abs(direction) > _minimalSpeed)
        {
            _animator.SetBool(IsRun, true);

            if (direction < 0 && _revertLocalScale.x > 0)
            {
                Revert();
            }

            if (direction > 0 && _revertLocalScale.x < 0)
            {
                Revert();
            }
        }
        else
        {
            _animator.SetBool(IsRun, false);
        }
    }

    public void Attack()
    {
        _animator.SetBool(IsAttack, true);
    }

    public void StopAttack()
    {
        _animator.SetBool(IsAttack, false);
    }

    public void Dead()
    {
        _animator.SetBool(IsDead, true);
    }

    private void Revert()
    {
        _revertLocalScale = new Vector3(_revertLocalScale.x * -1, _revertLocalScale.y, _revertLocalScale.z);
        transform.localScale = _revertLocalScale;
    }
}