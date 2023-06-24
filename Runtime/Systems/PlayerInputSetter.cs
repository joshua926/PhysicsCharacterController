using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Stubblefield.PhysicsCharacterController
{    
    public partial class PlayerInputSetter : SystemBase
    {
        PlayerInput playerInput;
        double jumpTime;
        float2 moveInput;
        float2 lookInput;

        protected override void OnCreate()
        {
            playerInput = new PlayerInput();
            playerInput.Enable();
            playerInput.OnFoot.run.performed += WriteRun;
            playerInput.OnFoot.run.canceled += WriteRun;
            playerInput.OnFoot.look.performed += WriteLook;
            playerInput.OnFoot.look.canceled += WriteLook;
            playerInput.OnFoot.jump.performed += WriteJump;
        }

        protected override void OnDestroy()
        {
            playerInput.OnFoot.run.performed -= WriteRun;
            playerInput.OnFoot.run.canceled -= WriteRun;
            playerInput.OnFoot.look.performed -= WriteLook;
            playerInput.OnFoot.look.canceled -= WriteLook;
            playerInput.OnFoot.jump.performed -= WriteJump;
        }

        protected override void OnUpdate()
        {
            foreach (var (playerID, run, look, jump) in SystemAPI.Query<
                PlayerID,
                RefRW<Run>,
                RefRW<Look>,
                RefRW<JumpTiming>>())
            {
                run.ValueRW.moveVector = moveInput;
                look.ValueRW.angles = CalculateNewLookAngles(look.ValueRO, lookInput, SystemAPI.Time.DeltaTime);
                if (jump.ValueRO.requestTime != jumpTime) jump.ValueRW.requestTime = jumpTime;
            }
        }

        void WriteRun(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Canceled)
            {
                moveInput = default;
            }
            else
            {
                moveInput = context.ReadValue<Vector2>();
            }
        }

        void WriteLook(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Canceled)
            {
                moveInput = default;
            }
            else
            {
                lookInput = context.ReadValue<Vector2>();
            }
        }

        void WriteJump(InputAction.CallbackContext context)
        {
            if (context.ReadValue<bool>())
            {
                jumpTime = SystemAPI.Time.ElapsedTime;
            }
        }

        static float2 CalculateNewLookAngles(Look look, float2 lookInput, float deltaTime)
        {
            float2 angleOffset = new float2(-lookInput.y, lookInput.x);
            angleOffset.x *= look.VerticalSpeed;
            angleOffset.y *= look.HorizontalSpeed;
            angleOffset *= deltaTime;

            float2 angle = look.angles + angleOffset;
            angle.x = math.clamp(angle.x, Look.minVerticalAngle, Look.maxVerticalAngle);
            angle.y %= math.PI * 2;

            return angle;
        }
    }
}