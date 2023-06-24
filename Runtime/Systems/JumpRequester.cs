using Unity.Burst;
using Unity.Entities;

namespace Stubblefield.PhysicsCharacterController
{    
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