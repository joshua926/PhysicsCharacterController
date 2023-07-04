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
            new JobWithTime()
            {
                ellapsedTime = SystemAPI.Time.ElapsedTime,
            }.ScheduleParallel();
        }

        [BurstCompile]
        [WithNone(typeof(FreeFallTime))]
        [WithOptions(EntityQueryOptions.IgnoreComponentEnabledState)]
        partial struct Job : IJobEntity
        {

            public void Execute(
                EnabledRefRW<FreeFall> freeFall,
                in Acceleration acceleration, 
                in Gravity gravity)
            {
                freeFall.ValueRW = math.dot(acceleration.value, gravity.direction) > gravity.magnitude * .9f;
            }
        }

        [BurstCompile]
        [WithOptions(EntityQueryOptions.IgnoreComponentEnabledState)]
        partial struct JobWithTime : IJobEntity
        {
            public double ellapsedTime;

            public void Execute(
                EnabledRefRW<FreeFall> freeFall,
                ref FreeFallTime time,
                in Acceleration acceleration,
                in Gravity gravity)
            {
                bool isFreeFalling = math.dot(acceleration.value, gravity.direction) > gravity.magnitude * .9f;
                if (isFreeFalling != freeFall.ValueRO)
                {
                    if (isFreeFalling)
                    {
                        time.startTime = ellapsedTime;
                    }
                    else
                    {
                        time.endTime = ellapsedTime;
                    }
                }
                freeFall.ValueRW = isFreeFalling;
            }
        }
    }
}
