using alpoLib.Sample.UI;
using alpoLib.Sample.UI.Hud;
using UnityEngine;

namespace alpoLib.Sample.InGame.Feature.UI
{
    public class InGameKillCountFeatureUI : InGameFeatureUIBase<InGameKillCountFeature>
    {
        private readonly IFeatureUIKillCount _killCountUI;
        
        public InGameKillCountFeatureUI(InGameSceneUI sceneUI, IFeatureUIKillCount killCountUI) : base(sceneUI)
        {
            _killCountUI = killCountUI;
        }
        
        public void SetKillCount(int killCount)
        {
            _killCountUI?.SetKillCount(killCount);
        }
    }
}