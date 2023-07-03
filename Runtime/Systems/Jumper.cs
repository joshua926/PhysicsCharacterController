using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Extensions;

namespace Stubblefield.PhysicsCharacterController
{   
    [BurstCompile]
    public partial struct Jumper : ISystem
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
                EnabledRefRW<Jump> jump,
                ref PhysicsVelocity velocity,
                in JumpParams jumpParams,
                in Gravity gravity,
                in PhysicsMass mass)
            {                
                float3 force = -gravity.direction * jumpParams.force;
                velocity.ApplyLinearImpulse(mass, force);
                jump.ValueRW = false;
            }
        }
    }
}