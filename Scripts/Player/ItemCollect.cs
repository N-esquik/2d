using UnityEngine;

[RequireComponent(typeof(Player))]

public class ItemCollect : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Apple apple))
        {
            _player.HealthRegen();
            Destroy(apple.gameObject);
        }
    }
}