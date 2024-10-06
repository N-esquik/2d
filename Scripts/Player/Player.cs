using UnityEngine;

[RequireComponent (typeof(PlayerAnimation))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private int _maxHealth = 100;

    private PlayerAnimation _playerAnimation;
    private int _healthRegen = 50;

    public int Health => _health;
    public int MaxHealth => _maxHealth;
    public bool IsDead => _health <= 0;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    public void HealthRegen()
    {
        if (_health < _maxHealth)
        {
            _health += _healthRegen;

            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
        }
    }

    public void Hit(int damage)
    {
        _health -= damage;
        _playerAnimation.Hit();

        if (IsDead)
        {
            Destroy(gameObject);
        }
    }
}
