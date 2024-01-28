using UnityEngine;

public class SkeletonVision : MonoBehaviour
{
    [SerializeField] private SkeletonMovement _skeletonMovement;
    [SerializeField] private SkeletonAttack _skeletonAttack;
    [SerializeField] private BoxCollider2D _boxCollider;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _skeletonMovement.StartFollow(player.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _skeletonMovement.StopFollow();
    }

    public void StopVision()
    {
        _boxCollider.enabled = false;
    }

    public void StartVision()
    {
        _boxCollider.enabled = true;
    }
}