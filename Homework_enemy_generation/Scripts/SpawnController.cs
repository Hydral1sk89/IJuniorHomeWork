using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawns;
    [SerializeField] private List<Transform> _directions;
    [SerializeField] private SkeletonWalk _unit;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _countSkeletons;

    private Coroutine _createUnit;

    private void Start()
    {
        _createUnit = StartCoroutine(CreateMonster(_spawnDelay));
    }

    private IEnumerator CreateMonster(float delay)
    {
        for (int i = 0; i < _countSkeletons; i++)
        {
            var wait = new WaitForSecondsRealtime(delay);

            yield return wait;

            int randomSpawner = Random.RandomRange(0, _spawns.Count);
            int randomDirection = Random.RandomRange(0, _directions.Count);

            Vector3 position = _spawns[randomSpawner].position;

            SkeletonWalk skeleton = Instantiate(_unit, position, Quaternion.identity);
            skeleton.SetTarget(_directions[randomDirection]);
        }
    }
}
