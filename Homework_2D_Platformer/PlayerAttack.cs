using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _hitPlace;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private float _damage = 1;

    private float _hitTime = 0.08f;
    private Coroutine _HitTimeJob;

    private void Awake()
    {
        _hitPlace.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            var enemyHealth = enemy.GetComponentInParent<SkeletonHealth>();
            enemyHealth.TakeDamage(_damage);
        }
    }

    public void Attack()
    {
        _playerAnimation.Attack();
        _hitPlace.enabled = true;
        _HitTimeJob = StartCoroutine(HitTime());
    }

    private IEnumerator HitTime()
    {
        var wait = new WaitForSeconds(_hitTime);
        yield return wait;
        _playerAnimation.StopAttack();
        _hitPlace.enabled = false;
        StopCoroutine(_HitTimeJob);
    }
}