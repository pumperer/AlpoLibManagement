using System;
using alpoLib.Sample.UI;
using UnityEngine;

namespace alpoLib.Sample.InGame.Feature.UI
{
    public interface IInGameFeatureUI
    {
        Type GetPairFeatureType();
        void OnAttachFeature(IInGameFeature feature);
        void OnOpen();
        void OnClose();
    }
    
    public class InGameFeatureUIBase<T> : IInGameFeatureUI where T : IInGameFeature
    {
        protected InGameFeatureUIBase(InGameSceneUI sceneUI)
        {
            
        }
        
        public Type GetPairFeatureType()
        {
            return typeof(T);
        }
        
        public virtual void OnAttachFeature(IInGameFeature feature)
        {
            
        }

        public virtual void OnOpen()
        {
            
        }

        public virtual void OnClose()
        {
            
        }
    }
}