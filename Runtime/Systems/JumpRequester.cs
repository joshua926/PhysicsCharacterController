/*
const float gravityEqualityToleranceFactor = .1f;

bool isGrounded

bool preGraceJump = time  - jump.preGroundedGraceDuration;
bool postGraceJump = jump.requestTime < time + jump.postGroundedGraceDuration;


if (!jump.jumpRequested) return;
jump.jumpRequested = false;
if (!groundCheck.isGrounded) return;
groundCheck.isGrounded = false;
float3 force = math.up() * jump.jumpForce;
velocity.ApplyLinearImpulse(mass, force);
*/

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
    [UpdateAfter(typeof(IsGroundedSetter))]
    [UpdateAfter(typeof(PlayerInputSetter))]
    [BurstCompile]
    public partial struct JumpRequester : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            new Job()
            {
                time = SystemAPI.Time.ElapsedTime,
            }.ScheduleParallel();
        }

        [BurstCompile]
        partial struct Job : IJobEntity
        {
            public double time;

            [BurstCompile]
            public void Execute(
                ref Jump jump,
                ref JumpTiming jumpTiming,
                in IsGrounded isGrounded)                 
            {
                bool liveRequest = jumpTiming.requestTime > jumpTiming.performedTime;
                bool tooSoonAfterJump = time < jumpTiming.performedTime + jumpTiming.postJumpWaitDuration;
                bool tooSoonBeforeGrounding = isGrounded.Value && time > jumpTiming.requestTime + jumpTiming.preGroundedGraceDuration;
                bool tooLateAfterUnGrounding = !isGrounded.Value && time > isGrounded.TimeOfLastGrounded + jumpTiming.postGroundedGraceDuration;

                if (liveRequest && !tooSoonAfterJump && !tooSoonBeforeGrounding && !tooLateAfterUnGrounding)
                {
                    jump.JumpRequested = true;
                    jumpTiming.performedTime = time;
                }
                else
                {
                    jumpTiming.requestTime = 0;
                }
            }
        }
    }
}