using alpoLib.Sample.Character;
using alpoLib.Sample.InGame.Feature.UI;
using alpoLib.Sample.Scene;
using UnityEngine;

namespace alpoLib.Sample.InGame.Feature
{
    public class InGameKillCountFeature : InGameFeatureBase
    {
        private InGameKillCountFeatureUI UI => FeatureUI as InGameKillCountFeatureUI;
        private int _killCount;
        
        public InGameKillCountFeature(InGameScene scene) : base(scene)
        {
            _killCount = 0;
        }

        public override void OnKill(CharacterBase attacker, CharacterBase killed)
        {
            if (!attacker || !killed)
                return;
            _killCount++;
            UI?.SetKillCount(_killCount);
        }
    }
}