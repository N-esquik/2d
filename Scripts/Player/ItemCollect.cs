using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    private Player _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Apple apple))
        {
            if (_playerHealth.Health < _playerHealth.MaxHealth)
            {
                _playerHealth.HealthRegen(apple.HealthRegen);
                Destroy(apple.gameObject);
            }
        }
    }
}