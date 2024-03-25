using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private Medkit _medkit;
    [SerializeField] private float _timeBetweenSpawn;

    private Transform[] _pointsContainer;
    private Medkit _currentMedkit;

    private Coroutine _delayJob;

    private void Start()
    {
        _pointsContainer = new Transform[_point.childCount];

        for (int i = 0; i < _point.childCount; i++)
        {
            _pointsContainer[i] = _point.GetChild(i);
        }

        Spawn();
    }

    public void Spawn()
    {
        int index = GetRandomSpawnPointIndex();
        _currentMedkit = Instantiate(_medkit, _pointsContainer[index].transform.position, Quaternion.identity);
        _currentMedkit.MedkitTaken += StartDelay;
    }

    private int GetRandomSpawnPointIndex()
    {
        return Random.Range(0, _pointsContainer.Length);
    }

    private void StartDelay()
    {
        if (_delayJob == null)
        {
            _currentMedkit.MedkitTaken -= StartDelay;
            StartCoroutine(DelaySpawn());
        }
    }

    private IEnumerator DelaySpawn()
    {
        var wait = new WaitForSeconds(_timeBetweenSpawn);
        yield return wait;

        Spawn();
    }
}