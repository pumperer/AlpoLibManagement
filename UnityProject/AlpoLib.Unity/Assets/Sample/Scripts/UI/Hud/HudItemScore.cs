using alpoLib.UI.Hud;
using TMPro;
using UnityEngine;

namespace alpoLib.Sample.UI.Hud
{
    public interface IFeatureUIScore
    {
        void UpdateScore(int score);
    }
    
    public class HudItemScore : HudItemBase, IFeatureUIScore
    {
        [Header("점수")]
        [SerializeField] protected TMP_Text scoreText;
        
        private const string ScoreFormat = "Score : {0}";
        
        protected override void OnInitialize()
        {
            base.OnInitialize();
            UpdateScore(0);
        }

        public void UpdateScore(int score)
        {
            if (scoreText)
                scoreText.text = string.Format(ScoreFormat, score);
        }
    }
}