using Unity.Burst;
using Unity.Collections;
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
                ref Jump jump,
                ref PhysicsVelocity velocity,
                in Gravity gravity,
                in PhysicsMass mass)
            {
                if (jump.JumpRequested)
                {
                    float3 force = -gravity.direction * jump.Force;
                    velocity.ApplyLinearImpulse(mass, force);
                    jump.JumpRequested = false;
                }
            }
        }
    }
}