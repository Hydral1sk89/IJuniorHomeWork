using System.Collections;
using UnityEngine;

public class EnemyGenerator : ObjectPool
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private Coroutine _SpawnCoroutine;

    private void OnEnable()
    {
        _SpawnCoroutine = StartCoroutine(SpawnEnemy());
    }

    private void OnDisable()
    {
        if (_SpawnCoroutine != null)
            StopCoroutine(_SpawnCoroutine);
    }

    private void Start()
    {
        Initialize(_enemies);
    }

    private IEnumerator SpawnEnemy()
    {
        var wait = new WaitForSeconds(_secondsBetweenSpawn);

        while (enabled)
        {
            if (TryGetObject(out Enemy enemy))
            {
                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                enemy.transform.position = spawnPoint;
                enemy.gameObject.SetActive(true);
                enemy.StartShooting();

                DisableObjectAbroadAScreen();
            }

            yield return wait;
        }
    }
}