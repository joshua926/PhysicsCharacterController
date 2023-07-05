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
            new Job()
            {
                deltaTime = SystemAPI.Time.DeltaTime,
            }.ScheduleParallel();
        }

        [BurstCompile]
        partial struct Job : IJobEntity
        {
            public float deltaTime;            

            [BurstCompile]
            public void Execute(
                ref LocalTransform local,
                in Look look,
                in LookParams lookParams,
                in Gravity gravity)
            {
                float3 aim = local.Forward();
                float3 up = -gravity.direction;
                float3 right = math.cross(up, aim);

                float currentVerticalAngle = Math.rightAngle - Math.Angle(aim, up);
                float newVerticalAngle = currentVerticalAngle + look.speed.x * deltaTime;
                newVerticalAngle = math.clamp(
                    newVerticalAngle, 
                    lookParams.allowedAngleRange.x, 
                    lookParams.allowedAngleRange.y);
                float verticalAngleDelta = newVerticalAngle - currentVerticalAngle;

                quaternion verticalRotation = quaternion.AxisAngle(right, verticalAngleDelta);
                quaternion horizontalRotation = quaternion.AxisAngle(up, look.speed.y);
                aim = math.mul(verticalRotation, aim);
                aim = math.mul(horizontalRotation, aim);
                local.Rotation = quaternion.LookRotation(aim, up);
            }
        }
    }
}