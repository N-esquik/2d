using UnityEngine;

public static class AnimatorData
{
    public static readonly int Speed = Animator.StringToHash(nameof(Speed));
    public static readonly int DieEnemy = Animator.StringToHash(nameof(DieEnemy));
    public static readonly int Hit = Animator.StringToHash(nameof(Hit));
}