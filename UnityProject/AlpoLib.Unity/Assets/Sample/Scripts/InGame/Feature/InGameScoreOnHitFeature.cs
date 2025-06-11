using alpoLib.Sample.Character;
using alpoLib.Sample.InGame.Feature.UI;
using alpoLib.Sample.Scene;
using UnityEngine;

namespace alpoLib.Sample.InGame.Feature
{
    public class InGameScoreOnHitFeature : InGameFeatureBase
    {
        private InGameScoreOnHitFeatureUI _ui => FeatureUI as InGameScoreOnHitFeatureUI;
        private int _scorePerHit;
        private int _score;

        public InGameScoreOnHitFeature(InGameScene scene, int scorePerHit) : base(scene)
        {
            _scorePerHit = scorePerHit;
            _score = 0;
        }
        
        public override void OnHit(CharacterBase attacker, float damage, CharacterBase hitter)
        {
            if (!hitter)
                return;
            
            _score += _scorePerHit;
            Debug.Log($"Score increased by {_scorePerHit}. Total score: {_score}");
            _ui?.SetScore(_score);
        }
    }
}