using System.Collections.Generic;
using alpoLib.Sample.InGame.Feature.UI;
using alpoLib.Sample.Scene;
using alpoLib.Sample.UI.Hud;
using alpoLib.UI;
using alpoLib.UI.Hud;

namespace alpoLib.Sample.UI
{
    public class InGameSceneUI : SceneUIBase
    {
        private InGameScene Scene => CurrentScene as InGameScene;
        private readonly HashSet<IInGameFeatureUI> _uiFeatures = new();
        private HudItemController _hudItemController;

        public override void OnInitialize()
        {
            base.OnInitialize();
            _hudItemController = new HudItemController(GetComponentsInChildren<HudItemBase>(true));
            
            AddFeatureUI(new InGameScoreOnHitFeatureUI(this, _hudItemController.FindFirstHudItem<IFeatureUIScore>()));
            AddFeatureUI(new InGameKillCountFeatureUI(this, _hudItemController.FindFirstHudItem<IFeatureUIKillCount>()));
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