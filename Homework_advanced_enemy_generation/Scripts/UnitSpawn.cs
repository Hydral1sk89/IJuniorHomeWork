using System.Collections;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private EnemyWalk _unit;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _numberUnitsSpawn;

    private Coroutine _createUnit;

    private void Start()
    {
        _createUnit = StartCoroutine(CreateUnit(_spawnDelay));
    }

    private IEnumerator CreateUnit(float delay)
    {
        var wait = new WaitForSecondsRealtime(delay);

        for (int i = 0; i < _numberUnitsSpawn; i++)
        {
            yield return wait;

            EnemyWalk unit = Instantiate(_unit, transform.position, Quaternion.identity);
            unit.SetTarget(_target);
        }
    }
}