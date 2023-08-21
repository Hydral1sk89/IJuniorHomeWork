using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private Coin _coin;
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
        Coin coin = Instantiate(_coin, _points[index].transform.position, Quaternion.identity);
        coin.Init(this);
    }

    private int GetRandomSpawnPointIndex()
    {
        int spawnPointIndex = Random.Range(0, _points.Length);

        return spawnPointIndex;
    }
}
