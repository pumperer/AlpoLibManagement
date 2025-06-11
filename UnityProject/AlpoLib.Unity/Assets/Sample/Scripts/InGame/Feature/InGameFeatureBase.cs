using alpoLib.Sample.Character;
using alpoLib.Sample.InGame.Feature.UI;
using alpoLib.Sample.Scene;
using alpoLib.Sample.UI;
using UnityEngine;

namespace alpoLib.Sample.InGame.Feature
{
    public interface IInGameFeature
    {
        void AttachUIFeature(IInGameFeatureUI featureUI);
        
        void OnOpen();
        void OnClose();

        void OnUpdate(float deltaTime, float timeScale);
        void OnHit(CharacterBase attacker, float damage, CharacterBase hitter);
        void OnKill(CharacterBase attacker, CharacterBase killed);
        
    }
    
    public abstract class InGameFeatureBase : IInGameFeature
    {
        protected InGameScene Scene { get; private set; }
        protected IInGameFeatureUI FeatureUI { get; private set; }

        protected InGameFeatureBase(InGameScene scene)
        {
            Scene = scene;
        }
        
        public void AttachUIFeature(IInGameFeatureUI featureUI)
        {
            FeatureUI = featureUI;
        }
        
        public virtual void OnOpen()
        {
        }

        public virtual void OnClose()
        {
        }

        public virtual void OnUpdate(float deltaTime, float timeScale)
        {
        }

        public virtual void OnHit(CharacterBase attacker, float damage, CharacterBase hitter)
        {
        }
        
        public virtual void OnKill(CharacterBase attacker, CharacterBase killed)
        {
        }
    }
}