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
            new JobWithTime()
            {
                ellapsedTime = SystemAPI.Time.ElapsedTime,
            }.ScheduleParallel();          
        }

        [BurstCompile]
        [WithNone(typeof(JumpTime))]
        partial struct Job : IJobEntity
        {
            public double ellapsedTime;

            [BurstCompile]
            public void Execute(
                EnabledRefRW<Jump> jump,
                ref PhysicsVelocity velocity,
                in JumpParams jumpParams,
                in Gravity gravity,
                in PhysicsMass mass)
            {
                velocity.ApplyLinearImpulse(mass, -gravity.direction * jumpParams.force);
                jump.ValueRW = false;
            }
        }

        [BurstCompile]
        partial struct JobWithTime : IJobEntity
        {
            public double ellapsedTime;

            [BurstCompile]
            public void Execute(
                EnabledRefRW<Jump> jump,
                ref JumpTime time,
                ref PhysicsVelocity velocity,
                in JumpParams jumpParams,
                in Gravity gravity,
                in PhysicsMass mass)
            {
                velocity.ApplyLinearImpulse(mass, -gravity.direction * jumpParams.force);
                jump.ValueRW = false;
                time.startTime = ellapsedTime;
            }
        }
    }
}