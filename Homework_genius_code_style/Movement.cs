using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;

    private Transform[] _targets;
    private int _indexPosition;
    private float _speed;


    private void Start()
    {
        _targets = new Transform[_targetPosition.childCount];

        for (int i = 0; i < _targetPosition.childCount; i++)
        {
            _targets[i] = _targetPosition.GetChild(i);
        }
    }

    private void Update()
    {
        var target = _targets[_indexPosition];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            GetNextTargetPosition();
        }
    }

    private Vector3 GetNextTargetPosition()
    {
        _indexPosition++;

        if (_indexPosition == _targets.Length)
        {
            _indexPosition = 0;
        }

        var targetPosition = _targets[_indexPosition].transform.position;
        transform.forward = targetPosition - transform.position;

        return targetPosition;
    }
}