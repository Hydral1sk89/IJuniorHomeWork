using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class SkeletonMovement : MonoBehaviour
{
    [SerializeField] Transform _leftTurningPoint;
    [SerializeField] Transform _rightTurningPoint;
    [SerializeField] private float _speed;
    [SerializeField] private SkeletonAnimation _skeletonAnimation;
    [SerializeField] private SkeletonAttack _skeletonAttack;
    [SerializeField] private SkeletonHealth _skeletonHealth;
    [SerializeField] private bool _isPatrol = true;
    [SerializeField] private bool _isFollow = false;

    private Transform _target;
    private Transform _playerTransform;
    private Vector3 _revertLocalScale;
    private float _minimalSpeed;
    private float _speedMagnitude;

    private void Awake()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
    }

    private void Start()
    {
        _target = _rightTurningPoint;
        _revertLocalScale = transform.localScale;
    }

    private void Update()
    {
        StartCoroutine(CalculateSpeed());

        if (_isPatrol == true)
            Patrol();

        if (_isFollow == true)
            Move(_playerTransform);
    }

    public void StartFollow(Transform position)
    {
        _isPatrol = false;
        _isFollow = true;
        _playerTransform = position;

        LookAt(position);
    }

    public void StopFollow()
    {
        _isPatrol = true;
        _isFollow = false;
        LookAt(_target);
    }

    public void StopMove()
    {
        _isPatrol = false;
        _isFollow = false;
    }

    private void LookAt(Transform position)
    {
        if (transform.position.x < position.position.x)
        {
            _revertLocalScale = new Vector3(Mathf.Abs(_revertLocalScale.x), _revertLocalScale.y, _revertLocalScale.z);
            transform.localScale = _revertLocalScale;
        }
        else
        {
            _revertLocalScale = new Vector3(Mathf.Abs(_revertLocalScale.x) * -1, _revertLocalScale.y, _revertLocalScale.z);
            transform.localScale = _revertLocalScale;
        }
    }

    private void Move(Transform target)
    {
        if (transform.position.x > target.position.x)
        {
            transform.Translate(_speed * Time.deltaTime * transform.right * -1);
        }
        else
        {
            transform.Translate(_speed * Time.deltaTime * transform.right);
        }
    }

    private void Patrol()
    {
        if (Mathf.Abs(_speedMagnitude) > _minimalSpeed)
        {
            _skeletonAnimation.Walk();
        }
        else
        {
            _skeletonAnimation.StopWalk();
        }

        Move(_target);

        if (transform.position == _leftTurningPoint.position)
        {
            _target = _rightTurningPoint;
            LookAt(_target);
        }
        if (transform.position == _rightTurningPoint.position)
        {
            _target = _leftTurningPoint;
            LookAt(_target);
        }
    }

    private IEnumerator CalculateSpeed()
    {
        Vector3 lastPosition = transform.position;
        yield return new WaitForFixedUpdate();
        _speedMagnitude = (lastPosition - transform.position).magnitude;
    }
}