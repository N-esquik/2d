using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(Health))]

public class Player : MonoBehaviour
{
    private PlayerAnimation _playerAnimation;
    private Health _health;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _health = GetComponent<Health>();
    }

    public void Hit(int damage)
    {
        _health.TakeDamage(damage);
        _playerAnimation.Hit();

        if (_health.IsDead)
        {
            Destroy(gameObject);
        }
    }
}
