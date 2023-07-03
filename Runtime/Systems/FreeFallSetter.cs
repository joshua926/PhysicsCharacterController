using Unity.Entities;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;

namespace Stubblefield.PhysicsCharacterController
{
    [BurstCompile]
    public partial struct FreeFallSetter : ISystem
    {

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            new Job().ScheduleParallel();
        }

        [BurstCompile]
        partial struct Job : IJobEntity
        {

            public void Execute(
                EnabledRefRW<FreeFall> freeFall,
                in Acceleration acceleration, 
                in Gravity gravity)
            {
                float downwardAccelerationMagnitude = math.dot(acceleration.value, gravity.direction);
                freeFall.ValueRW = downwardAccelerationMagnitude > gravity.magnitude * .9f;
            }
        }
    }
}
