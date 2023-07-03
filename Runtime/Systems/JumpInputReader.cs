using Unity.Burst;
using Unity.Entities;

namespace Stubblefield.PhysicsCharacterController
{    
    [BurstCompile]
    public partial struct JumpInputReader : ISystem
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
                //ref Jump jump,
                EnabledRefRW<Jump> isJump,
                ref JumpInput input,
                EnabledRefRO<FreeFall> freeFall)                 
            {
                //bool liveRequest = input.time > request.performedTime;
                //bool tooSoonAfterJump = time < request.performedTime + request.postJumpWaitDuration;
                //bool tooSoonBeforeGrounding = isGrounded.Value && time > request.inputTime + request.preGroundedGraceDuration;
                //bool tooLateAfterUnGrounding = !isGrounded.Value && time > isGrounded.TimeOfLastGrounded + request.postGroundedGraceDuration;

                //if (liveRequest && !tooSoonAfterJump && !tooSoonBeforeGrounding && !tooLateAfterUnGrounding)
                //{
                //    isJump.JumpRequested = true;
                //    request.performedTime = time;
                //}
                //else
                //{
                //    request.inputTime = 0;
                //}
            }
        }
    }
}