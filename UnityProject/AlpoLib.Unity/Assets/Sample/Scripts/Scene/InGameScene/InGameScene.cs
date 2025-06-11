using System;
using System.Collections.Generic;
using alpoLib.Sample.Character;
using alpoLib.Sample.InGame.Feature;
using alpoLib.Sample.UI;
using alpoLib.UI.Scene;
using UnityEngine;

namespace alpoLib.Sample.Scene
{
    public interface IHit
    {
        void OnHit(CharacterBase attacker, float damage, CharacterBase hitter);
    }

    [SceneDefine("Sample/Addr/Scenes/InGameScene.unity", SceneResourceType.Addressable)]
    public class InGameScene : SceneBaseWithUI<InGameSceneUI>, IHit
    {
        [SerializeField] protected MainPlayer mainPlayer;

        private HashSet<IInGameFeature> _features = new();
        private Dictionary<Type, IInGameFeature> _featureDic = new();

        public override void OnOpen()
        {
            base.OnOpen();
            AddFeature(new InGameScoreOnHitFeature(this, 10));
            SceneUI.InitFeatures();
            
            mainPlayer.Initialize(this);
        }

        private void AddFeature(InGameFeatureBase feature)
        {
            _features.Add(feature);
            _featureDic.Add(feature.GetType(), feature);
        }

        public IInGameFeature GetFeature(Type featureType)
        {
            if (_featureDic.TryGetValue(featureType, out var feature))
                return feature;
            return null;
        }

        public T GetFeature<T>() where T : IInGameFeature
        {
            return (T)GetFeature(typeof(T));
        }

        public void OnHit(CharacterBase attacker, float damage, CharacterBase hitter)
        {
            foreach (var feature in _features)
                feature.OnHit(attacker, damage, hitter);
        }
    }
}