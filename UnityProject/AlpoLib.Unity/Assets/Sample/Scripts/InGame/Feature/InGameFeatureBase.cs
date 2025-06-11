using UnityEngine;

namespace alpoLib.Sample.InGame.Feature
{
    public interface IInGameFeature
    {
        void OnOpen();
        void OnClose();

        void OnUpdate(float deltaTime, float timeScale);

        
    }
    
    public abstract class InGameFeatureBase : IInGameFeature
    {
        public virtual void OnOpen()
        {
        }

        public virtual void OnClose()
        {
        }

        public virtual void OnUpdate(float deltaTime, float timeScale)
        {
        }
    }
}