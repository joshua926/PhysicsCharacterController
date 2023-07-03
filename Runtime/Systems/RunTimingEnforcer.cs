//using Unity.Burst;
//using Unity.Entities;

//namespace Stubblefield.PhysicsCharacterController
//{
//    [BurstCompile]
//    public partial struct RunTimingEnforcer : ISystem
//    {
//        [BurstCompile]
//        public void OnUpdate(ref SystemState state)
//        {
//            new Job()
//            {
//                time = SystemAPI.Time.ElapsedTime,
//            }.ScheduleParallel();
//        }

//        [BurstCompile]
//        partial struct Job : IJobEntity
//        {
//            public double time;

//            [BurstCompile]
//            public void Execute(
//                ref RunParams run,
//                ref RunInput request,
//                in IsGrounded isGrounded)
//            {
//                bool liveRequest = request.inputTime > request.performedTime;
//                bool tooSoonBeforeGrounding = isGrounded.Value && time > request.inputTime + request.preGroundedGraceDuration;
//                bool tooLateAfterUnGrounding = !isGrounded.Value && time > isGrounded.TimeOfLastGrounded + request.postGroundedGraceDuration;

//                if (liveRequest && !tooSoonBeforeGrounding && !tooLateAfterUnGrounding)
//                {
//                    run.value = request.value;
//                    request.performedTime = time;
//                }
//                else
//                {
//                    request.inputTime = 0;
//                }
//            }
//        }
//    }
//}