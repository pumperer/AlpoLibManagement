using System;
using System.Collections.Generic;
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
}

public enum ActionState
{
    Idle,
    Attack,
}

public abstract class CharacterBase : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    
    protected AnimatorState? CurrentAnimatorState = null;

    protected ActionBase CurrentAction = null;

    private int _upperLayerIndex = 1;

    private Dictionary<ActionState, ActionBase> _actionMap = new();
    
    private void Awake()
    {
        if (animator)
            _upperLayerIndex = animator.GetLayerIndex("Upper");
        
        var idleAction = new IdleAction(new ActionContext()
        {
            ActionDuration = 0f,
            OnActionCompleted = null,
        });
        var attackAction = new AttackAction(new ActionContext()
        {
            ActionDuration = 0.833f,
            OnActionCompleted = OnActionCompleted
        });
        _actionMap.Add(ActionState.Idle, idleAction);
        _actionMap.Add(ActionState.Attack, attackAction);
        
        SetState(AnimatorState.Idle);
        SetAction(ActionState.Idle);
        
        OnAwake();
    }

    private void Start()
    {
        OnStart();
    }

    private void Update()
    {
        CurrentAction?.UpdateAction(Time.deltaTime);
        OnUpdate();
    }

    protected virtual void OnAwake()
    {
        
    }

    protected virtual void OnStart()
    {
        
    }
    
    protected virtual void OnUpdate()
    {
        
    }

    private void OnActionCompleted(ActionBase completedAction)
    {
        if (CurrentAction == completedAction)
        {
            CurrentAction = null;
            if (animator)
                animator.CrossFade(nameof(AnimatorState.Idle), 0.25f, _upperLayerIndex);
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

    public void SetAction(ActionState actionState)
    {
        CurrentAction?.CancelAction();
        if (!_actionMap.TryGetValue(actionState, out var action))
            return;
        CurrentAction = action;
        if (CurrentAction == null)
            return;
        
        CurrentAction.StartAction();
        
        if (animator)
            animator.CrossFade(CurrentAction.ActionName, 0.25f, _upperLayerIndex);
    }
}
