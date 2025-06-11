using UnityEngine;

namespace alpoLib.Sample.Character.Weapon
{
    public class Sword : WeaponBase
    {
        [Header("Sword")]
        [SerializeField] protected float attackRange = 2f;
        [SerializeField] protected float attackDamage = 10f;

        public override float Range => attackRange;
        public override float Damage => attackDamage;

        protected override void OnEquip(CharacterBase character)
        {
            if (character is MainPlayer mainPlayer)
            {
                mainPlayer.SetAttackRange(attackRange);
            }
        }

        protected override void OnUnEquip(CharacterBase character)
        {
            
        }
    }
}