using System.Collections.Generic;
using alpoLib.UI;
using TMPro;
using UnityEngine;

namespace alpoLib.Sample
{
    public abstract class SceneUIWithDebugLogLabel : SceneUIBase
    {
        [SerializeField] protected TMP_Text debugLabel;
        
        private List<string> _debugLabelStringList = new();
        private int _maxDebugLabelCount = 100;

        protected void AppendDebugText(string text)
        {
            AddDebugLabel(text);
            
            var txt = string.Join("\n", _debugLabelStringList);
            debugLabel.text = txt;
        }

        private void AddDebugLabel(string text)
        {
            _debugLabelStringList.Insert(0, text);
            if (_debugLabelStringList.Count > _maxDebugLabelCount)
                _debugLabelStringList.RemoveAt(_debugLabelStringList.Count - 1);
        }
    }
}