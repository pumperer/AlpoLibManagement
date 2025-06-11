using System;
using alpoLib.Core.Foundation;
using alpoLib.Sample.Behavior;
using UnityEngine;

namespace alpoLib.Sample.Character
{
    public class AttackRange : MonoBehaviour
    {
        private static int _enemyLayer;
        [SerializeField] protected SphereCollider rangeCollider;
        private CharacterBase _character;
        private ReferenceCountBool _shouldAttack;
        
        private void Awake()
        {
            _character = GetComponentInParent<CharacterBase>();
            _enemyLayer = LayerMask.NameToLayer("Enemy");
        }
        
        public void SetRange(float range)
        {
            if (!rangeCollider)
                return;
            rangeCollider.radius = range;
            // rangeCollider.size = new Vector3(1, 1, range);
            // rangeCollider.center = new Vector3(0, 0.5f, range * 0.5f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != _enemyLayer)
                return;
            Debug.Log($"Object entered attack range: {other.name}");
            _shouldAttack++;
            if (_shouldAttack == 1)
                _character.SetAction(ActionState.Attack, true);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer != _enemyLayer)
                return;
            Debug.Log($"Object exited attack range: {other.name}");
            _shouldAttack--;
            if (_shouldAttack == 0)
                _character.SetAction(ActionState.Idle);
        }
    }
}