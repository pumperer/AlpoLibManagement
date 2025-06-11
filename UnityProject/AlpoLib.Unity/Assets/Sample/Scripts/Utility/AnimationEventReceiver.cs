using System;
using UnityEngine;

namespace alpoLib.Sample.Utility
{
    public interface IAnimationEventReceiver
    {
        void OnAnimationEventImpl(AnimationEvent animationEvent);
    }
    
    public class AnimationEventReceiver : MonoBehaviour
    {
        [SerializeField] private IAnimationEventReceiver[] receivers;
        
        private void Awake()
        {
            receivers = GetComponentsInParent<IAnimationEventReceiver>(true);
        }

        public void OnAnimationEvent(AnimationEvent animationEvent)
        {
            foreach (var r in receivers)
            {
                r.OnAnimationEventImpl(animationEvent);
            }
        }
    }
}