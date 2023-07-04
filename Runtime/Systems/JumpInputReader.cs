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
                ellapsedTime = SystemAPI.Time.ElapsedTime,
            }.ScheduleParallel();
        }

        [BurstCompile]
        [WithOptions(EntityQueryOptions.IgnoreComponentEnabledState)]
        partial struct Job : IJobEntity
        {
            public double ellapsedTime;
            public ComponentLookup<Jump> jumpLookup;

            [BurstCompile]
            public void Execute(
                EnabledRefRW<JumpInput> jumpInput,
                EnabledRefRW<Jump> jump,
                ref JumpInputTime jumpInputTime,
                in JumpTime jumpTime,
                EnabledRefRO<FreeFall> freeFall,
                in FreeFallTime freeFallTime)                 
            {
                if (!jumpInput.ValueRO) return;

                bool tooSoonAfterJump = ellapsedTime < jumpTime.startTime + jumpInputTime.postJumpWaitDuration;
                bool tooSoonBeforeGrounding = !freeFall.ValueRO & ellapsedTime > jumpInputTime.inputTime + jumpInputTime.preGroundedGraceDuration;
                bool tooLateAfterUnGrounding = freeFall.ValueRO & ellapsedTime > freeFallTime.startTime + jumpInputTime.postGroundedGraceDuration;

                if (!tooSoonAfterJump & !tooSoonBeforeGrounding & !tooLateAfterUnGrounding)
                {
                    jumpInputTime.inputTime = ellapsedTime;
                    jumpInput.ValueRW = false;
                    jump.ValueRW = true;
                }                
            }
        }
    }
}