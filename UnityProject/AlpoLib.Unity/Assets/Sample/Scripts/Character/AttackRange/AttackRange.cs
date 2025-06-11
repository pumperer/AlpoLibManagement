using System;
using alpoLib.Core.Foundation;
using alpoLib.Sample.Behavior;
using alpoLib.Util;
using UnityEngine;

namespace alpoLib.Sample.Character
{
    public class AttackRange : MonoBehaviour
    {
        private TriggerObserver _triggerObserver;
        private static int _enemyLayer;
        [SerializeField] protected SphereCollider rangeCollider;
        private CharacterBase _character;
        private ReferenceCountBool _shouldAttack;
        
        private void Awake()
        {
            _triggerObserver = GetComponent<TriggerObserver>();
            _triggerObserver.OnTriggerEnterEvent += OnEnter;
            _triggerObserver.OnTriggerExitEvent += OnExit;
            _character = GetComponentInParent<CharacterBase>();
            _enemyLayer = LayerMask.NameToLayer("Enemy");
        }

        private void OnDestroy()
        {
            if (_triggerObserver)
            {
                _triggerObserver.OnTriggerEnterEvent -= OnEnter;
                _triggerObserver.OnTriggerExitEvent -= OnExit;
            }
        }

        public void SetRange(float range)
        {
            if (!rangeCollider)
                return;
            rangeCollider.radius = range;
        }

        private void OnEnter(Collider other)
        {
            if (!other || other.gameObject.layer != _enemyLayer)
                return;
            Debug.Log($"Object entered attack range: {other.name}");
            _shouldAttack++;
            if (_shouldAttack == 1)
                _character.SetAction(ActionState.Attack, true);

            var n = other.GetComponent<TriggerExitNotifier>();
            if (!n)
                n = other.gameObject.AddComponent<TriggerExitNotifier>();
            n.Initialize(_triggerObserver);
        }
        
        private void OnExit(Collider other)
        {
            if (!other || other.gameObject.layer != _enemyLayer)
                return;
            Debug.Log($"Object exited attack range: {other.name}");
            _shouldAttack--;
            if (_shouldAttack == 0)
                _character.SetAction(ActionState.Idle);
        }
    }
}