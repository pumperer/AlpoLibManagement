using System;
using alpoLib.Core.Foundation;
using alpoLib.Sample.Behavior;
using UnityEngine;

namespace alpoLib.Sample.Character
{
    public class AttackRange : MonoBehaviour
    {
        private static int _enemyLayer;
        
        private CharacterBase _character;

        private ReferenceCountBool _shouldAttack;
        
        private void Awake()
        {
            _character = GetComponentInParent<CharacterBase>();
            _enemyLayer = LayerMask.NameToLayer("Enemy");
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