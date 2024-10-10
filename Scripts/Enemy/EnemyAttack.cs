using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private int _damage = 50;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Vector3 enemyPosition = transform.position;
            Vector3 playerPosition = collision.transform.position;

            if (playerPosition.y < enemyPosition.y)
            {
                if (player != null)
                {
                    player.Hit(_damage);
                }
            }
        }
    }
}
