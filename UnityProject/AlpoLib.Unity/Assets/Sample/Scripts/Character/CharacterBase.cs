using System;
using Unity.Behavior;
using UnityEditor.Animations;
using UnityEngine;

[BlackboardEnum]
public enum AnimatorState
{
    Idle,
    Move,
    Run,
    Bread,
    Attack,
}

public abstract class CharacterBase : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    
    protected AnimatorState? CurrentAnimatorState = null;

    protected ActionBase CurrentAction = null;

    private int _upperLayerIndex = 1;

    private AttackAction _attackAction;
    
    protected virtual void Awake()
    {
        if (animator)
            _upperLayerIndex = animator.GetLayerIndex("Upper");

        _attackAction = new AttackAction();
    }

    private void Start()
    {
        SetState(AnimatorState.Idle);
    }
    
    private void OnActionCompleted(ActionBase completedAction)
    {
        if (CurrentAction == completedAction)
        {
            CurrentAction = null;
        }
    }
    
    public void SetState(AnimatorState state)
    {
        if (CurrentAnimatorState == state)
            return;
        
        CurrentAnimatorState = state;
        if (animator)
            animator.CrossFade(state.ToString(), 0.25f);
    }

    public void SetAttackAction()
    {
        CurrentAction?.CancelAction();
        CurrentAction = _attackAction;
        if (CurrentAction == null)
            return;
        
        CurrentAction.StartAction();
        
        if (animator)
            animator.CrossFade(CurrentAction.ActionName, 0.25f, _upperLayerIndex);
    }
}
