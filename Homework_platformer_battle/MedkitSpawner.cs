using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private Medkit _medkit;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_point.childCount];

        for (int i = 0; i < _point.childCount; i++)
        {
            _points[i] = _point.GetChild(i).transform;
        }

        Spawn();
    }

    public void Spawn()
    {
        int index = GetRandomSpawnPointIndex();
        Medkit medkit = Instantiate(_medkit, _points[index].transform.position, Quaternion.identity);
        medkit.Init(this);
    }

    private int GetRandomSpawnPointIndex()
    {
        int spawnPointIndex = Random.Range(0, _points.Length);

        return spawnPointIndex;
    }
}