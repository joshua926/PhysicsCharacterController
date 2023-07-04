using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Extensions;
using Unity.Transforms;

namespace Stubblefield.PhysicsCharacterController
{
    [BurstCompile]
    public partial struct Looker : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            new Job().ScheduleParallel();
        }

        [BurstCompile]
        partial struct Job : IJobEntity
        {

            [BurstCompile]
            public void Execute(
                ref LocalTransform local,
                in LookParams look)
            {

                //local.Rotation = quaternion.Euler(new float3(look.angles, 0));
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