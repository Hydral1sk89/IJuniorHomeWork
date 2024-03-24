using UnityEngine;

[RequireComponent(typeof(SkeletonAnimation))]
public class SkeletonHealth : MonoBehaviour
{
    [SerializeField] private float _health = 3;
    [SerializeField] private SkeletonMovement _skeletonMovement;
    [SerializeField] private SkeletonAttack _skeletonAttack;
    [SerializeField] private SkeletonVision _skeletonVision;

    private SkeletonAnimation _skeletonAnimation;

    private void Start()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>(); 
    }

    public void TakeDamage(float damage)
    {
        if (_health > 0)
        {
            _health -= damage;
            _skeletonAnimation.TakeDamage();
        }
        else
        {
            _skeletonVision.StopVision();
            _skeletonAttack.StopAttack();
            _skeletonMovement.StopMove();
            _skeletonAnimation.Dead();
        }
    }
}