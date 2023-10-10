using UnityEngine;

public class BulletCatcher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Bullet bullet))
        {
            Destroy(bullet.gameObject);
        }

        if(collision.TryGetComponent(out EnemyBullet enemyBullet))
        {
            Destroy(enemyBullet.gameObject);
        }
    }
}
