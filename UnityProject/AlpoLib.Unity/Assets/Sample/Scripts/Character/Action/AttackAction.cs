using alpoLib.Sample.Character.Weapon;
using UnityEngine;

namespace alpoLib.Sample.Character
{
    public class AttackAction : ActionBase
    {
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
            var hits = Physics.OverlapSphere(pos, _weapon.Range);
            if (hits.Length == 0)
            {
                Debug.LogWarning("No enemies in range for attack.");
                return;
            }
            foreach (var hit in hits)
            {
                if (hit.gameObject.layer != LayerMask.NameToLayer("Enemy"))
                    continue;
                var dir = hit.transform.position - pos;
                var angle = Vector3.Angle(Owner.transform.forward, dir.normalized);
                if (angle <= 15f)
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