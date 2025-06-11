using System;
using UnityEngine;

namespace alpoLib.Sample.Character.Weapon
{
    public abstract class WeaponBase : MonoBehaviour
    {
        // [SerializeField] protected Collider weaponCollider;
        protected CharacterBase CharacterOwner;

        public virtual float Range => 0f;
        public virtual float Damage => 0f;
        public virtual float HitOnTime => 0.5f;
        public virtual float AttackDuration => 0.833f;
        
        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnAwake()
        {
        }

        // public void SetWeaponActive(bool isActive)
        // {
        //     weaponCollider.enabled = isActive;
        // }
        
        // public void OnTriggerEnter(Collider other)
        // {
        //     if (!CharacterOwner)
        //         return;
        //     
        //     if (!other)
        //     {
        //         Debug.LogError("Collider is null");
        //         return;
        //     }
        //
        //     if (other.gameObject.layer != LayerMask.NameToLayer("Enemy"))
        //         return;
        //
        //     if (!other.TryGetComponent(out CharacterBase character))
        //         return;
        //     
        //     if (character == CharacterOwner)
        //         return;
        //     
        //     CharacterOwner.AttackTo(this, character);
        // }

        public void Equip(CharacterBase character)
        {
            CharacterOwner = character;
            OnEquip(character);
        }
        
        public void UnEquip(CharacterBase character)
        {
            if (CharacterOwner == character)
                CharacterOwner = null;
            OnUnEquip(character);
        }

        protected virtual void OnEquip(CharacterBase character)
        {
        }
        
        protected virtual void OnUnEquip(CharacterBase character)
        {
        }
    }
}