using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _walkAnimation;

    private Transform[] _points;
    private int _currentPoint;
    private int _doorPoint = 2;

    private void Start()
    {
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

                if (_currentPoint == _doorPoint)
                {
                    StartCoroutine(Wait(3f));
                }
            }
        }
    }

    private IEnumerator Wait(float seconds)
    {
        var wait = new WaitForSeconds(seconds);

        _speed = 0;
        _walkAnimation.SetBool("IsWalk", false);

        yield return wait;
        _speed = 2;
        _walkAnimation.SetBool("IsWalk", true);
    }
}
