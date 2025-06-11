using System;
using alpoLib.Sample.Character.Weapon;
using UnityEngine;

namespace alpoLib.Sample.Character
{
    public class AttackAction : ActionBase
    {
        private Collider[] _hits = new Collider[10];
        private WeaponBase _weapon;
        
        public AttackAction(ActionContext actionContext) : base(actionContext)
        {
        }
        
        public void EquipWeapon(WeaponBase weapon)
        {
            _weapon = weapon;
            // _weapon.SetWeaponActive(false);
        }
        
        private void AttackEnemyInRange()
        {
            if (_weapon == null)
                return;

            var pos = Owner.transform.position;
            Array.Fill(_hits, null);
            var size = Physics.OverlapSphereNonAlloc(pos, _weapon.Range, _hits, LayerMask.GetMask("Enemy"));
            if (size == 0)
            {
                Debug.LogWarning("No enemies in range for attack.");
                return;
            }

            for (var index = 0; index < size; index++)
            {
                var hit = _hits[index];
                if (!hit)
                    continue;
                if (hit.gameObject.layer != LayerMask.NameToLayer("Enemy"))
                    continue;
                var dir = hit.transform.position - pos;
                var angle = Vector3.Angle(Owner.transform.forward, dir.normalized);
                if (angle <= 90f)
                {
                    if (hit.TryGetComponent(out EnemyBase enemy))
                    {
                        Owner.AttackTo(_weapon, enemy);
                    }
                    else
                    {
                        Debug.LogWarning("No enemies in hit.");
                    }
                }
                else
                {
                    Debug.LogWarning("No enemies in angle." + angle);
                }
            }
        }

        public override void OnAnimationEventImpl(AnimationEvent animationEvent)
        {
            switch (animationEvent.stringParameter)
            {
                case "AttackOn":
                    // _weapon.SetWeaponActive(true);
                    AttackEnemyInRange();
                    break;
                case "AttackOff":
                    // _weapon.SetWeaponActive(false);
                    break;
            }
        }
    }
}