using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Stubblefield.PhysicsCharacterController
{
    [BurstCompile]
    public partial struct LookSetterFromInput : ISystem
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
        partial struct Job : IJobEntity
        {
            public double ellapsedTime;

            [BurstCompile]
            public void Execute(
                ref Look look,
                in LookParams lookParams,
                in LookInput lookInput)
            {               
                look.speed = new float2(-lookInput.value.y, lookInput.value.x) * lookParams.maxSpeed;
            }
        }
    }
}