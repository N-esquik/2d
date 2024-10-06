using UnityEngine;

[RequireComponent (typeof(ChickenAnimation))]

public class Enemy : MonoBehaviour
{
    private ChickenAnimation _chickenAnimation;

    private void Awake()
    {
        _chickenAnimation = GetComponent<ChickenAnimation>();
    }

    public void Die()
    {
        _chickenAnimation.Die();
        
        Destroy(gameObject);
    }
}
