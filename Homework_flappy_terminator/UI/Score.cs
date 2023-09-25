using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _score;

    private int _scoreQuantity;

    private List<Enemy> _enemies = new List<Enemy>();

    private void OnEnable()
    {
        _bird.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _bird.ScoreChanged -= OnScoreChanged;

        foreach (var enemy in _enemies)
        {
            enemy.Died -= OnDied;
        }
    }

    public void ResetScore()
    {
        _scoreQuantity = 0;
        SetScoreText(_scoreQuantity);
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }

    public void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
        enemy.Died += OnDied;
    }

    private void OnDied()
    {
        _scoreQuantity++;
        SetScoreText(_scoreQuantity);
    }

    private void SetScoreText(int score)
    {
        _score.text = score.ToString();
    }
}
