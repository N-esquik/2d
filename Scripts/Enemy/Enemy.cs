using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ChickenAnimation _chickenAnimation;

    private void Awake()
    {
        _chickenAnimation = GetComponent<ChickenAnimation>();
    }

    public void DieChicken()
    {
        _chickenAnimation.Die();
        
        Destroy(gameObject);
    }
}
