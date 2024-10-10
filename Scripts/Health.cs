using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _healthPoint;
    [SerializeField] private int _maxHealthPoint;

    public int HealthPoint => _healthPoint;

    public bool IsDead => _healthPoint <= 0;

    public void HealthRegen(int healthRegen)
    {
        if(_healthPoint < _maxHealthPoint)
        {
            _healthPoint += healthRegen;

            if(_healthPoint > _maxHealthPoint)
            {
                 _healthPoint = _maxHealthPoint;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        _healthPoint -= damage;
    }
}
