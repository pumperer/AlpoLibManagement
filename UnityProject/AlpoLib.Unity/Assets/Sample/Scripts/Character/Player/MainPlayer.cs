using alpoLib.Sample.Behavior;
using alpoLib.Sample.Character.Weapon;
using UnityEngine;

namespace alpoLib.Sample.Character
{
    public class MainPlayer : PlayerBase
    {
        [Header("Attack")]
        [SerializeField] protected AttackRange attackRangeComp;

        private WeaponBase _currentWeapon;

        protected override void OnAwake()
        {
            base.OnAwake();
            var weapon = GetComponentInChildren<WeaponBase>();
            EquipWeapon(weapon);
        }

        public void EquipWeapon(WeaponBase weapon)
        {
            _currentWeapon = weapon;
            _currentWeapon.Equip(this);

            if (GetAction(ActionState.Attack) is AttackAction aa)
                aa.EquipWeapon(weapon);
        }

        public void SetAttackRange(float attackRange)
        {
            if (attackRangeComp)
                attackRangeComp.SetRange(attackRange);
        }

        protected override void OnActionStartImpl(ActionBase action)
        {
            base.OnActionStartImpl(action);
            // if (_currentWeapon)
            //     _currentWeapon.SetWeaponActive(false);
        }
        
        protected override void OnActionEndImpl(ActionBase action)
        {
            base.OnActionEndImpl(action);
            // if (_currentWeapon)
            //     _currentWeapon.SetWeaponActive(false);
        }
    }
}