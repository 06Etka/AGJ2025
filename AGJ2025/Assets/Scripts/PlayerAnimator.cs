using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [Header("Player Avatar Refrence")]
    [Tooltip("Avatar Refrence for the Player")]
    [SerializeField] Avatar playerAvatar;

    [Header("Animation State")]
    [Tooltip("Current Animation State of the Player")]
    [SerializeField] PlayerAnimationState currentState = PlayerAnimationState.Idle;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if(playerAvatar != null && animator.avatar != playerAvatar)
        {
            animator.avatar = playerAvatar;
        }

        SetAnimationState(currentState);
    }

    public void SetAnimationState(PlayerAnimationState newState)
    {
        currentState = newState;
        animator.SetInteger("State", (int)currentState);
    }
 
    public void SetAnimationState(int newStateIndex)
    {
        SetAnimationState((PlayerAnimationState)newStateIndex);
    }

}

/// <summary> Represents animation states a player can be in during gameplay.</summary>
public enum PlayerAnimationState
{
    Idle = 0,
    Walking = 1,
    Attacking = 2, //Can be expanded to specific attack types
}