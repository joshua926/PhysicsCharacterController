using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Extensions;
using Unity.Physics.Systems;

namespace Stubblefield.PhysicsCharacterController
{
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateBefore(typeof(PhysicsSystemGroup))]
    [UpdateAfter(typeof(GroundChecker))]
    [BurstCompile]
    public partial struct Jumper : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            new CharacterJumperJob()
            {
                time = SystemAPI.Time.ElapsedTime,
            }.ScheduleParallel();
        }

        [BurstCompile]
        partial struct CharacterJumperJob : IJobEntity
        {
            public double time;

            [BurstCompile]
            public void Execute(
                ref Jump jump,
                ref PhysicsVelocity velocity,
                in Acceleration acceleration,
                in Gravity gravity,
                in PhysicsMass mass)
            {
                const float gravityEqualityToleranceFactor = .1f;

                bool isGrounded
               
                bool preGraceJump = time  - jump.preGraceDuration;
                bool postGraceJump = jump.requestTime < time + jump.postGraceDuration;


                if (!jump.jumpRequested) return;
                jump.jumpRequested = false;
                if (!groundCheck.isGrounded) return;
                groundCheck.isGrounded = false;
                float3 force = math.up() * jump.jumpForce;
                velocity.ApplyLinearImpulse(mass, force);
            }
        }
    }
}