using UnityEngine;

public class ChickenAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move(float speed)
    {
        _animator.SetFloat(AnimatorData.Speed, Mathf.Abs(speed));
    }

    public void Die(bool isDie)
    {
        if (isDie)
        {
            _animator.SetTrigger(AnimatorData.DieEnemy);
        }
    }
}