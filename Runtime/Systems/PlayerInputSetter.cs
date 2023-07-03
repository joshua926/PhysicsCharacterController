using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Stubblefield.PhysicsCharacterController
{    
    public partial class PlayerInputSetter : SystemBase
    {
        PlayerInput playerInput;
        double jumpRequestTime;
        double moveRequestTime;
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
            //foreach (var (playerID, run, look, jump) in SystemAPI.Query<
            //    PlayerID,
            //    RefRW<RunInput>,
            //    RefRW<LookParams>,
            //    RefRW<JumpInput>>())
            //{
            //    look.ValueRW.angles = CalculateNewLookAngles(look.ValueRO, lookInput, SystemAPI.Time.DeltaTime);
            //    if (run.ValueRO.inputTime != moveRequestTime)
            //    {
            //        run.ValueRW.inputTime = moveRequestTime;
            //        run.ValueRW.value = moveInput;
            //    }
            //    if (jump.ValueRO.time != jumpRequestTime)
            //    {
            //        jump.ValueRW.time = jumpRequestTime;
            //    }
            //}
        }

        void WriteRun(InputAction.CallbackContext context)
        {
            moveRequestTime = SystemAPI.Time.ElapsedTime;
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
                lookInput = default;
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
                jumpRequestTime = SystemAPI.Time.ElapsedTime;
            }
        }

        //static float2 CalculateNewLookAngles(LookParams look, float2 lookInput, float deltaTime)
        //{
        //    float2 angleOffset = new float2(-lookInput.y, lookInput.x);
        //    angleOffset.x *= look.VerticalMaxSpeed;
        //    angleOffset.y *= look.HorizontalMaxSpeed;
        //    angleOffset *= deltaTime;

        //    float2 angle = look.angles + angleOffset;
        //    angle.x = math.clamp(angle.x, LookParams.minVerticalAngle, LookParams.maxVerticalAngle);
        //    angle.y %= math.PI * 2;

        //    return angle;
        //}
    }
}