using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]

public class SkeletonMovement : MonoBehaviour
{
    private const string IsWalk = nameof(IsWalk);

    [SerializeField] private float _speed;
    [SerializeField] Transform _leftTurningPoint;
    [SerializeField] Transform _rightTurningPoint;

    private Transform _target;
    private float _minimalSpeed;
    private Animator _animator;
    private float _speedMagnitude;
    private Vector3 _revertLocalScale;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _target = _rightTurningPoint;
        _revertLocalScale = transform.localScale;
    }

    private void Update()
    {
        StartCoroutine(CalculateSpeed());

        if (Mathf.Abs(_speedMagnitude) > _minimalSpeed)
        {
            _animator.SetBool(IsWalk, true);
        }
        else
        {
            _animator.SetBool(IsWalk, false);
        }

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _leftTurningPoint.position)
        {
            _target = _rightTurningPoint;
            Revert();
        }
        if (transform.position == _rightTurningPoint.position)
        {
            _target = _leftTurningPoint;
            Revert();
        }
    }

    private IEnumerator CalculateSpeed()
    {
        Vector3 lastPosition = transform.position;
        yield return new WaitForFixedUpdate();
        _speedMagnitude = (lastPosition - transform.position).magnitude;
    }

    private void Revert()
    {
        _revertLocalScale = new Vector3(_revertLocalScale.x * -1, _revertLocalScale.y, _revertLocalScale.z);
        transform.localScale = _revertLocalScale;
    }
}
