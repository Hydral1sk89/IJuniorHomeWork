using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private Score _score;
    [SerializeField] private int _capacity;

    private Camera _camera;
    private List<Enemy> _pool = new List<Enemy>();

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.ResetBullets();
            item.gameObject.SetActive(false);
        }
    }

    protected void Initialize(Enemy[] prefabs)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            Enemy enemy = Instantiate(prefabs[randomIndex], _container.transform);
            _score.AddEnemy(enemy);
            enemy.gameObject.SetActive(false);

            _pool.Add(enemy);
        }
    }

    protected bool TryGetObject(out Enemy result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAbroadAScreen()
    {
        foreach (var item in _pool)
        {
            Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

            if (item.gameObject.activeSelf == true)
            {
                if (item.transform.position.x < disablePoint.x)
                    item.gameObject.SetActive(false);
            }
        }
    }
}
