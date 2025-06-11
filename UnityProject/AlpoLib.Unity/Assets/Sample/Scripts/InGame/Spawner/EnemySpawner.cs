using System;
using System.Collections.Generic;
using alpoLib.Sample.Character;
using alpoLib.Util;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace alpoLib.Sample.InGame
{
    public class EnemySpawner : SingletonMonoBehaviour<EnemySpawner>, IDisposable
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private EnemyObjectPool[] enemyObjectPools;

        public async Awaitable LoadAsync()
        {
            var awaitables = new Awaitable[enemyObjectPools.Length];
            for (var index = 0; index < enemyObjectPools.Length; index++)
            {
                var p = enemyObjectPools[index].LoadAsync();
                awaitables[index] = p;
            }
            await AwaitableHelper.WhenAll(awaitables);
        }
        
        public EnemyBase SpawnEnemy()
        {
            var pool = enemyObjectPools.GetRandom();
            var enemy = pool.Get();
            if (enemy == null)
            {
                Debug.LogError("Failed to get an enemy from the pool.");
                return null;
            }

            enemy.transform.position = spawnPoints.GetRandom().position;
            enemy.gameObject.SetActive(true);
            enemy.SetPooler(pool);
            
            return enemy;
        }
        
        public void ReleaseEnemy(EnemyBase enemy)
        {
            if (enemy == null)
            {
                Debug.LogError("Enemy is null.");
                return;
            }

            enemy.Pooler.Release(enemy); // Return the enemy to the pool
        }

        public void Dispose()
        {
            foreach (var pool in enemyObjectPools)
            {
                pool.Dispose();
            }
        }
    }

    [Serializable]
    public class EnemyObjectPool : alpoLib.Util.IObjectPool<EnemyBase>, IDisposable
    {
        [SerializeField] private AssetReferenceGameObject enemyPrefab;
        [SerializeField] private int preloadCount;
        
        private DefaultObjectPool<EnemyBase> _pool;

        public async Awaitable LoadAsync()
        {
            var h = enemyPrefab.LoadAssetAsync();
            h.Completed += handle =>
            {
                var p = handle.Result;
                _pool = new DefaultObjectPool<EnemyBase>(p);
                _pool.Preload(preloadCount);
            };
            await h.Task;
        }

        public void Dispose()
        {
            _pool?.Dispose();
            enemyPrefab.ReleaseAsset();
        }

        public EnemyBase Get()
        {
            return _pool?.Get();
        }

        public void Release(EnemyBase obj)
        {
            _pool?.Release(obj);
        }
    }
}