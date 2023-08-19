using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private EnemyWalk _unit;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _numberUnitsSpawn;
    [SerializeField] Transform _target;
    [SerializeField] Transform _path;

    private Coroutine _createUnit;

    private void Start()
    {
        _createUnit = StartCoroutine(CreateUnit(_spawnDelay));
    }

    private IEnumerator CreateUnit(float delay)
    {
        for (int i = 0; i < _numberUnitsSpawn; i++)
        {
            var wait = new WaitForSecondsRealtime(delay);

            yield return wait;

            EnemyWalk unit = Instantiate(_unit, transform.position, Quaternion.identity);
            unit.SetTarget(_target);
            unit.SetPath(_path);
        }
    }
}