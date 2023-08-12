using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private Animator _walkAnimation;

    private const string IsWalk = nameof(IsWalk);

    private Transform[] _points;
    private int _currentPoint;
    private int _indexPointDoorLocated = 2;
    private float _delay = 3f;
    private float _speed;
    private float _stay = 0f;
    private float _walkSpeed = 2f;

    private void Start()
    {
        _speed = _walkSpeed;
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i).transform;
        }
    }

    private void Update()
    {
        if (_currentPoint < _points.Length)
        {
            Transform target = _points[_currentPoint];

            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

            if (transform.position == target.position)
            {
                _currentPoint++;

                if (_currentPoint == _indexPointDoorLocated)
                {
                    StartCoroutine(Wait(_delay));
                }
            }
        }
    }

    private IEnumerator Wait(float seconds)
    {
        var wait = new WaitForSeconds(seconds);

        _speed = _stay;
        _walkAnimation.SetBool(IsWalk, false);

        yield return wait;
        _speed = _walkSpeed;
        _walkAnimation.SetBool(IsWalk, true);
    }
}