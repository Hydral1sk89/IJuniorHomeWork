using UnityEngine;

public class EnemyGenerator : ObjectPool
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_enemies);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime > _secondsBetweenSpawn)
        {
            if(TryGetObject(out Enemy enemy))
            {
                _elapsedTime = 0;

                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                enemy.gameObject.SetActive(true);
                enemy.transform.position = spawnPoint;

                DisableObjectAbroadAScreen();
            }
        }
    }
}
