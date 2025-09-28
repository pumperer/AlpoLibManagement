using System;
using System.Collections.Generic;
using alpoLib.Sample.Character;
using alpoLib.Sample.InGame;
using alpoLib.Sample.InGame.Feature;
using alpoLib.Sample.UI;
using alpoLib.UI.Scene;
using alpoLib.Util;
using UnityEngine;

namespace alpoLib.Sample.Scene
{
    public interface IFeatureInterface
    {
        void OnHit(CharacterBase attacker, float damage, CharacterBase hitter);
        void OnKill(CharacterBase attacker, CharacterBase killed);
    }

    [SceneDefine("Sample/Addr/Scenes/InGameScene.unity", SceneResourceType.Addressable)]
    public class InGameScene : SceneBaseWithUI<InGameSceneUI>, IFeatureInterface
    {
        [SerializeField] protected MainPlayer mainPlayer;

        private HashSet<IInGameFeature> _features = new();
        private Dictionary<Type, IInGameFeature> _featureDic = new();

        protected override void OnAwake()
        {
            base.OnAwake();
            IsLoadingComplete = false;
        }

        public override void OnOpen()
        {
            base.OnOpen();
            AwaitableHelper.Run(OnLoadAsync);
        }

        public override void OnClose()
        {
            base.OnClose();
            StopInternetCheck();
        }

        private async Awaitable OnLoadAsync()
        {
            AddFeature(new InGameScoreOnHitFeature(this, 10, 100));
            AddFeature(new InGameKillCountFeature(this));
            SceneUI.InitFeatures();
            
            await EnemySpawner.Instance.LoadAsync();
            
            mainPlayer.Initialize(this);
            for (var i = 0; i < 5; i++)
                SpawnEnemy();

            StartInternetCheck();

            IsLoadingComplete = true;
        }

        #region Feature Management
        
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
        
        #endregion

        #region Feature Broadcast
        
        public void OnHit(CharacterBase attacker, float damage, CharacterBase hitter)
        {
            foreach (var feature in _features)
                feature.OnHit(attacker, damage, hitter);
        }
        
        public void OnKill(CharacterBase attacker, CharacterBase killed)
        {
            foreach (var feature in _features)
                feature.OnKill(attacker, killed);
            
            Invoke(nameof(SpawnEnemy), 1f);
        }
        
        #endregion
        
        public void SpawnEnemy()
        {
            var enemy = EnemySpawner.Instance.SpawnEnemy();
            enemy?.Initialize(this);
        }

        private void StartInternetCheck()
        {
            InternetAvailableChecker.OnStatusChanged += OnInternetAvailableStatusChanged;
            InternetAvailableChecker.StartChecking();
        }

        private void StopInternetCheck()
        {
            InternetAvailableChecker.OnStatusChanged -= OnInternetAvailableStatusChanged;
            InternetAvailableChecker.StopChecking();
        }

        private void OnInternetAvailableStatusChanged(InternetAvailableChecker.EStatus prevStatus, InternetAvailableChecker.EStatus newStatus)
        {
            Debug.Log($"Internet status changed: {prevStatus} -> {newStatus}");
        }
    }
}