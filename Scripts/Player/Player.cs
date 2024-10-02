using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private int _maxHealth = 100;

    private PlayerAnimation _playerAnimation;

    public int Health => _health;
    public int MaxHealth => _maxHealth;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    public void HealthRegen(int health)
    {
        if (_health < _maxHealth)
        {
            _health += health;

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

        if (IsDead())
        {
            Destroy(gameObject);
        }
    }

    private bool IsDead()
    {
        return _health <= 0;
    }
}
