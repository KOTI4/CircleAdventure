using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        PlayerCollision.MineTouch += AnimDead;
        Manager.RestartScene += AnimIdle;
    }

    public void AnimDead() => animator.SetBool("Dead", true);
    public void AnimIdle() => animator.SetBool("Dead", false);
}
