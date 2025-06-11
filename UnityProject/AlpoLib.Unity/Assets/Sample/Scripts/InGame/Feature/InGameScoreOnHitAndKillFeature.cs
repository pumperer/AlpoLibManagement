using alpoLib.Sample.Character;
using alpoLib.Sample.InGame.Feature.UI;
using alpoLib.Sample.Scene;
using UnityEngine;

namespace alpoLib.Sample.InGame.Feature
{
    public class InGameScoreOnHitAndKillFeature : InGameFeatureBase
    {
        private InGameScoreOnHitAndKillFeatureUI UI => FeatureUI as InGameScoreOnHitAndKillFeatureUI;
        private readonly int _scorePerHit;
        private readonly int _scorePerKill;
        private int _score;

        public InGameScoreOnHitAndKillFeature(InGameScene scene, int scorePerHit, int scorePerKill) : base(scene)
        {
            _scorePerHit = scorePerHit;
            _scorePerKill = scorePerKill;
            _score = 0;
        }
        
        public override void OnHit(CharacterBase attacker, float damage, CharacterBase hitter)
        {
            if (!hitter)
                return;
            
            _score += _scorePerHit;
            Debug.Log($"Score increased by hit {_scorePerHit}. Total score: {_score}");
            UI?.SetScore(_score);
        }

        public override void OnKill(CharacterBase attacker, CharacterBase killed)
        {
            if (!killed)
                return;
            
            _score += _scorePerKill;
            Debug.Log($"Score increased by kill {_scorePerKill}. Total score: {_score}");
            UI?.SetScore(_score);
        }
    }
}