using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;

    private Transform[] _targets;
    private int indexPosition;
    private float _speed;

    void Start()
    {
        _targets = new Transform[_targetPosition.childCount];

        for (int i = 0; i < _targetPosition.childCount; i++)
        {
            _targets[i] = _targetPosition.GetChild(i).GetComponent<Transform>();
        }
    }

    public void Update()
    {
        var target = _targets[indexPosition];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            GetNextTargetPosition();
        }
    }

    public Vector3 GetNextTargetPosition()
    {
        indexPosition++;

        if (indexPosition == _targets.Length)
        {
            indexPosition = 0;
        }

        var targetPosition = _targets[indexPosition].transform.position;
        transform.forward = targetPosition - transform.position;

        return targetPosition;
    }
}