using UnityEngine;

[RequireComponent (typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
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

    public void Hit()
    {
        _animator.SetTrigger(AnimatorData.Hit);
    }
}