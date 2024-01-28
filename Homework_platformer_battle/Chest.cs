using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]

public class Chest : MonoBehaviour
{
    [SerializeField] private Transform _coinSpawnPoint;
    [SerializeField] private Medkit _coin;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerAnimation>(out PlayerAnimation player))
        {
            _animator.SetTrigger(0);
            Medkit coin = Instantiate(_coin, _coinSpawnPoint.transform.position, Quaternion.identity);
        }
    }
}
