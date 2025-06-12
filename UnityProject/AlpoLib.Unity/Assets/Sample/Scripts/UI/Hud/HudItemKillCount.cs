using TMPro;
using UnityEngine;

namespace alpoLib.Sample.UI.Hud
{
    public interface IFeatureUIKillCount
    {
        void SetKillCount(int count);
    }
    
    public class HudItemKillCount : HudItemBase, IFeatureUIKillCount
    {
        [Header("킬 카운트")]
        [SerializeField] protected TMP_Text killCountText;

        private const string KillCountFormat = "Kill : {0}";
        
        protected override void OnInitialize()
        {
            base.OnInitialize();
            SetKillCount(0);
        }
        
        public void SetKillCount(int count)
        {
            if (killCountText)
                killCountText.text = string.Format(KillCountFormat, count);
        }
    }
}