using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : ScoreDisplay
{
    [SerializeField] private Bird _bird;

    private int _scoreQuantity;

    private List<Enemy> _enemies = new List<Enemy>();

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= OnDied;
        }
    }

    public void ResetScore()
    {
        _scoreQuantity = 0;
        Display(_scoreQuantity);
    }

    public void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
        enemy.Died += OnDied;
    }

    private void OnDied()
    {
        _scoreQuantity++;
        Display(_scoreQuantity);
    }
}
