using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SkeletonAttack : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] BoxCollider2D _hitPlace;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private SkeletonVision _skeletonVision;

    private SkeletonAnimation _skeletonAnimation;
    private SkeletonMovement _skeletonMovement;
    private PlayerHealth _playerHealth;

    private Coroutine _hitJob;

    private void Awake()
    {
        _skeletonAnimation = GetComponentInParent<SkeletonAnimation>();
        _skeletonMovement = GetComponentInParent<SkeletonMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _skeletonMovement.StopMove();
            _skeletonAnimation.StopWalk();
            _playerHealth = player.GetComponentInParent<PlayerHealth>();

            _hitJob = StartCoroutine(Hit());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _playerHealth = null;
            _skeletonAnimation.StopAttack();
            _skeletonAnimation.Walk();
            _skeletonVision.StartVision();
            StopCoroutine(_hitJob);
        }
    }

    public void StopAttack()
    {
        _hitPlace.enabled = false;
    }

    private IEnumerator Hit()
    {
        while (true)
        {
            _skeletonAnimation.Attack();

            var wait = new WaitForSeconds(_delay);
            yield return wait;

            _playerHealth.TakeDamage(_damage);
        }
    }
}