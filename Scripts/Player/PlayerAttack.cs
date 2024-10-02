using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private float _bounceForce = 2.5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Vector3 playerPosition = transform.position;
            Vector3 enemyPosition = collision.transform.position;

            float distance = 0.2f;

            if (playerPosition.y > enemyPosition.y + distance)
            {
                enemy.DieChicken();

                _rigidbody.velocity = new Vector2(0, _bounceForce);
            }
        }
    }
}
