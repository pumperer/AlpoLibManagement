using System.Collections.Generic;
using alpoLib.Sample.Behavior;
using alpoLib.Sample.Character.Weapon;
using alpoLib.Sample.Scene;
using alpoLib.Sample.Utility;
using UnityEngine;
using AnimatorState = alpoLib.Sample.Behavior.AnimatorState;

namespace alpoLib.Sample.Character
{
    public abstract class CharacterBase : MonoBehaviour, IAnimationEventReceiver
    {
        [SerializeField] protected float maxHealth;
        [SerializeField] protected Animator animator;
        [SerializeField] protected Collider hitCollider;

        protected AnimatorState? CurrentAnimatorState = null;
        protected ActionBase CurrentAction = null;
        protected float currentHealth;
        protected bool isDie = false;

        private int _upperLayerIndex = 1;

        private Dictionary<ActionState, ActionBase> _actionMap = new();

        protected IHit HitInterface;

        private void Awake()
        {
            if (animator)
                _upperLayerIndex = animator.GetLayerIndex("Upper");

            var idleAction = new IdleAction(new ActionContext()
            {
                ActionState = ActionState.Idle,
                ActionDuration = 0f,
                OnActionCompleted = null,
            });
            var attackAction = new AttackAction(new ActionContext()
            {
                ActionState = ActionState.Attack,
                ActionDuration = 0.833f,
                OnActionCompleted = OnActionCompleted,
                Owner = this,
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

        public void Initialize(IHit hit)
        {
            currentHealth = maxHealth;
            isDie = false;
            hitCollider.enabled = true;
            HitInterface = hit;
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

        protected virtual void OnActionStartImpl(ActionBase action)
        {
            
        }
        
        protected virtual void OnActionEndImpl(ActionBase action)
        {
        }

        protected virtual void OnDamageImpl(CharacterBase attacker, float damage)
        {
        }

        private void OnActionCompleted(ActionBase completedAction)
        {
            if (CurrentAction == completedAction)
            {
                CurrentAction = null;
                if (animator)
                    animator.CrossFade(nameof(AnimatorState.Idle), 0.25f, _upperLayerIndex);
                OnActionEndImpl(completedAction);
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

        public void SetAction(ActionState actionState, bool loop = false)
        {
            if (CurrentAction != null && CurrentAction.State == actionState)
                return;
            
            CurrentAction?.CancelAction();
            if (!_actionMap.TryGetValue(actionState, out var action))
                return;
            CurrentAction = action;
            if (CurrentAction == null)
                return;

            CurrentAction.StartAction(loop);
            OnActionStartImpl(CurrentAction);

            if (animator)
                animator.CrossFade(CurrentAction.State.ToString(), 0.25f, _upperLayerIndex);
        }

        protected ActionBase GetAction(ActionState actionState)
        {
            if (_actionMap.TryGetValue(actionState, out var action))
                return action;
            return null;
        }

        public void AttackTo(WeaponBase weapon, CharacterBase characterToAttack)
        {
            if (characterToAttack.isDie)
                return;
            
            HitInterface?.OnHit(this, weapon.Damage, characterToAttack);
            characterToAttack.DamageFrom(this, weapon.Damage);
            
        }

        public void DamageFrom(CharacterBase attacker, float damage)
        {
            if (isDie)
                return;
            
            currentHealth -= damage;
            OnDamageImpl(attacker, damage);
            if (currentHealth <= 0)
                Die();
        }

        public void Die()
        {
            isDie = true;
            hitCollider.enabled = false;
        }

        public void OnAnimationEventImpl(AnimationEvent animationEvent)
        {
            CurrentAction?.OnAnimationEventImpl(animationEvent);
        }
    }
}