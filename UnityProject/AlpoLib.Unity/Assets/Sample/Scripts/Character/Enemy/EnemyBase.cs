using alpoLib.Sample.Character.Weapon;
using alpoLib.Util;
using UnityEngine;

namespace alpoLib.Sample.Character
{
    public abstract class EnemyBase : CharacterBase
    {
        private IObjectPool<EnemyBase> _pooler;
        
        public IObjectPool<EnemyBase> Pooler => _pooler;
        
        public void SetPooler(IObjectPool<EnemyBase> pooler)
        {
            _pooler = pooler;
        }
        
        protected override void OnDie()
        {
            base.OnDie();
            _pooler?.Release(this);
        }
    }
}