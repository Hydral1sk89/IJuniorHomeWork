using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private int _speed;

    private Transform[] _points;
    private int _pointIndex;

    void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i).transform;
        }

        transform.position = _points[0].position;
    }

    private void Update()
    {
        if (transform.position == _points[_pointIndex].position)
        {
            if (_pointIndex < _points.Length - 1)
            {
                _pointIndex++;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _points[_pointIndex].position, _speed * Time.deltaTime);
    }
}
