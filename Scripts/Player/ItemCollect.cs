using UnityEngine;

[RequireComponent(typeof(Health))]

public class ItemCollect : MonoBehaviour
{
    private Health _health;
    private int _healthRegenApple = 50;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Apple apple))
        {
            _health.HealthRegen(_healthRegenApple);
            Destroy(apple.gameObject);
        }
    }
}