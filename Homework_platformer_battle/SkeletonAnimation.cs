using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SkeletonAnimation : MonoBehaviour
{
    private const string IsWalk = nameof(IsWalk);
    private const string TakeHit = nameof(TakeHit);
    private const string Hit = nameof(Hit);
    private const string IsDead = nameof(IsDead);

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Walk()
    {
        _animator.SetBool(IsWalk, true);
    }

    public void StopWalk()
    {
        _animator.SetBool(IsWalk, false);
    }

    public void TakeDamage()
    {
        _animator.SetBool(IsWalk, false);
        _animator.SetTrigger(TakeHit);
    }

    public void Attack()
    {
        _animator.SetBool(Hit, true);
    }

    public void StopAttack()
    {
        _animator.SetBool(Hit, false);
    }

    public void Dead()
    {
        _animator.SetTrigger(IsDead);
    }
}