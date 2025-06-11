using System;
using alpoLib.Sample.Behavior;
using UnityEngine;
using UnityEngine.InputSystem;

namespace alpoLib.Sample.Character
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(CharacterController))]
    public abstract class PlayerBase : CharacterBase
    {
        [Header("Movement Settings")] [SerializeField]
        protected float moveSpeed = 5f;

        [SerializeField] protected float gravity = -9.81f;
        [SerializeField] protected float jumpHeight = 2f;

        [Header("Rotation Settings")] [SerializeField]
        protected float rotationSpeed = 10f;

        protected CharacterController Controller;
        protected PlayerInput PlayerInput;

        private Vector2 inputMove;
        private Vector3 velocity;
        private bool isJumping;

        protected override void OnAwake()
        {
            base.OnAwake();
            Controller = GetComponent<CharacterController>();
            PlayerInput = GetComponent<PlayerInput>();
        }

        protected void OnEnable()
        {
            PlayerInput.actions.Enable();
        }

        protected void OnDisable()
        {
            PlayerInput.actions.Disable();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (!Mathf.Approximately(inputMove.sqrMagnitude, 0))
            {
                var move = new Vector3(inputMove.x, 0, inputMove.y);
                var targetRotation = Quaternion.LookRotation(move);
                transform.rotation =
                    Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                var moveDir = transform.forward;
                Controller.Move(moveDir * (moveSpeed * Time.deltaTime));
                SetState(AnimatorState.Move);
            }
            else
            {
                SetState(AnimatorState.Idle);
            }

            if (Controller.isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (isJumping && Controller.isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                isJumping = false;
            }

            velocity.y += gravity * Time.deltaTime;
            Controller.Move(velocity * Time.deltaTime);
        }

        public void Move(InputAction.CallbackContext context)
        {
            inputMove = context.ReadValue<Vector2>();
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Performed)
                return;

            isJumping = true;
        }

        public void Attack(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Performed)
                return;

            SetAction(ActionState.Attack);
        }
    }
}