using Unity.Entities;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;

namespace Stubblefield.PhysicsCharacterController
{
    [BurstCompile]
    public partial struct AccelerationSetter : ISystem
    {

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            new Job()
            {
                deltaTimeReciprocal = math.rcp(SystemAPI.Time.DeltaTime),
            }.ScheduleParallel();
        }

        [BurstCompile]
        partial struct Job : IJobEntity
        {
            public float deltaTimeReciprocal;

            public void Execute(
                ref Acceleration acceleration, 
                in PhysicsVelocity velocity)
            {
                acceleration.value = (velocity.Linear - acceleration.priorVelocity) * deltaTimeReciprocal;
                acceleration.priorVelocity = velocity.Linear;               
            }
        }
    }
}
