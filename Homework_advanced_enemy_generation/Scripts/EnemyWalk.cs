using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _path;
    private Transform _finalPoint;
    private Transform[] _points;
    private int _currentPoint;
    private Transform _target;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i).transform;
        }

        _target = _points[0];
    }

    private void Update()
    {
        if (_currentPoint < _points.Length)
        {
            if (IsInPosition())
            {
                _target = _points[_currentPoint];
                _currentPoint++;
            }
        }
        else
        {
            if (IsInPosition())
            {
                _target = _finalPoint;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private bool IsInPosition()
    {
        return transform.position == _target.position;
    }

    public void SetTarget(Transform target)
    {
        _finalPoint = target;
    }

    public void SetPath(Transform path)
    {
        _path = path;
    }
}