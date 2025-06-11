using System.Collections.Generic;
using alpoLib.Sample.InGame.Feature.UI;
using alpoLib.Sample.Scene;
using alpoLib.UI;
using UnityEngine;

namespace alpoLib.Sample.UI
{
    public class InGameSceneUI : SceneUIBase
    {
        private InGameScene Scene => CurrentScene as InGameScene;
        private HashSet<IInGameFeatureUI> _uiFeatures = new();

        public override void OnInitialize()
        {
            base.OnInitialize();
            AddFeatureUI(new InGameScoreOnHitAndKillFeatureUI(this));
        }

        private void AddFeatureUI(IInGameFeatureUI featureUI)
        {
            _uiFeatures.Add(featureUI);
        }

        public void InitFeatures()
        {
            foreach (var featureUI in _uiFeatures)
            {
                InitOneFeature(featureUI);
            }
        }
        
        private void InitOneFeature(IInGameFeatureUI featureUI)
        {
            var feature = Scene.GetFeature(featureUI.GetPairFeatureType());
            if (feature == null)
            {
                featureUI.OnClose();
                return;
            }
            
            feature.AttachUIFeature(featureUI);
            featureUI.OnAttachFeature(feature);
        }
    }
}