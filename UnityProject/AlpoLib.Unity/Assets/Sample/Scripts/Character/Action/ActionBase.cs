using System;
using UnityEngine;

namespace alpoLib.Sample.Character
{
    public struct ActionContext
    {
        public float ActionDuration;
        public Action<ActionBase> OnActionCompleted;
    }

    public abstract class ActionBase
    {
        public abstract string ActionName { get; }

        protected readonly float ActionDuration;
        protected readonly Action<ActionBase> OnActionCompleted;

        protected float elapsedTime;

        protected ActionBase(ActionContext actionContext)
        {
            ActionDuration = actionContext.ActionDuration;
            OnActionCompleted = actionContext.OnActionCompleted;
        }

        protected virtual void OnActionStart()
        {
        }

        protected virtual void OnActionEnd()
        {
            OnActionCompleted?.Invoke(this);
        }

        protected virtual void OnActionCancel()
        {
        }

        public virtual void StartAction()
        {
            elapsedTime = 0f;
            OnActionStart();
        }

        public virtual void UpdateAction(float deltaTime)
        {
            elapsedTime += deltaTime;
            if (elapsedTime < ActionDuration)
                return;

            OnActionEnd();
        }

        public virtual void CancelAction()
        {
            OnActionCancel();
        }
    }
}