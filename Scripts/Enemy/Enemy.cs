using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ChickenAnimation _chickenAnimation;


    private void Awake()
    {
        _chickenAnimation = GetComponent<ChickenAnimation>();
    }

    public void DieChicken(bool isDie)
    {
        if (isDie == false)
        {
            return;
        }

        _chickenAnimation.Die(isDie);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
