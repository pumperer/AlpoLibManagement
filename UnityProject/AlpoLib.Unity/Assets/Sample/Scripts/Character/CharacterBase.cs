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
    
    private void Awake()
    {
        if (animator)
            _upperLayerIndex = animator.GetLayerIndex("Upper");
        
        _attackAction = new AttackAction(new ActionContext()
        {
            ActionDuration = 0.833f,
            OnActionCompleted = OnActionCompleted
        });
        
        SetState(AnimatorState.Idle);
        
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
