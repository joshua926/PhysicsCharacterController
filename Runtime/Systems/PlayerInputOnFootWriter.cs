using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Stubblefield.PhysicsCharacterController
{
    public partial class PlayerInputOnFootWriter : SystemBase, PlayerInput.IOnFootActions
    {
        protected override void OnUpdate() { }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Performed) return;

            foreach (var (jumpInput, jumpInputTime) in SystemAPI.Query<
                EnabledRefRW<JumpInput>,
                RefRW<JumpInputTime>>())
            {
                jumpInput.ValueRW = true;
                jumpInputTime.ValueRW.inputTime = SystemAPI.Time.ElapsedTime;
            }
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            foreach (var lookInput in SystemAPI.Query<
                RefRW<LookInput>>())
            {
                lookInput.ValueRW.value = context.ReadValue<Vector2>();
            }
        }

        public void OnRun(InputAction.CallbackContext context)
        {
            foreach (var runInput in SystemAPI.Query<
                RefRW<RunInput>>())
            {
                runInput.ValueRW.value = context.ReadValue<Vector2>();
            }
        }
    }
}
