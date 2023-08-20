using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Animator))]

public class Player : MonoBehaviour
{
    private const string IsRun = nameof(IsRun);

    private Vector3 _revertLocalScale;
    private Animator _animator;
    private float _horizontalDirection;
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

    private void Revert()
    {
        _revertLocalScale = new Vector3(_revertLocalScale.x * -1, _revertLocalScale.y, _revertLocalScale.z);
        transform.localScale = _revertLocalScale;
    }
}
