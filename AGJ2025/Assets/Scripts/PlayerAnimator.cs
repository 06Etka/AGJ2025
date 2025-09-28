using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [Header("Animation State")]
    [Tooltip("Current Animation State of the Player")]
    [SerializeField] PlayerAnimationState currentState = PlayerAnimationState.Idle;
    private Animator animator;

    void Start()
    {
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
    Slash = 2,
    Roar = 2,
}