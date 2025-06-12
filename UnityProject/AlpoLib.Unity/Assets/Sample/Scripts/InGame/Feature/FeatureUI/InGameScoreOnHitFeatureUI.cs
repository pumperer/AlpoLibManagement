using alpoLib.Sample.UI;
using alpoLib.Sample.UI.Hud;
using UnityEngine;

namespace alpoLib.Sample.InGame.Feature.UI
{
    public class InGameScoreOnHitFeatureUI : InGameFeatureUIBase<InGameScoreOnHitFeature>
    {
        private readonly IFeatureUIScore _scoreUI;
        
        public InGameScoreOnHitFeatureUI(InGameSceneUI sceneUI, IFeatureUIScore scoreUI) : base(sceneUI)
        {
            _scoreUI = scoreUI;
        }
        
        public void SetScore(int score)
        {
            _scoreUI?.UpdateScore(score);
        }
    }
}