using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Stubblefield.PhysicsCharacterController
{
    [BurstCompile]
    public partial struct IsGroundedSetter : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            new IsGroundedSetterJob()
            {
                time = SystemAPI.Time.ElapsedTime,
            }.ScheduleParallel();
        }

        [BurstCompile]
        partial struct IsGroundedSetterJob : IJobEntity
        {
            public double time;

            [BurstCompile]
            public void Execute(
                ref IsGrounded isGrounded,
                in Gravity gravity,
                in Acceleration acceleration)
            {
                const float gravityEqualityToleranceFactor = .1f;
                float magnitudeOfProjectionOfAccelerationOnGravity = math.dot(acceleration.value, gravity.direction);
                float maxForIsGrounded = gravity.magnitude * (1 - gravityEqualityToleranceFactor);
                bool value = magnitudeOfProjectionOfAccelerationOnGravity < maxForIsGrounded; // if percentOfGravity is NaN, then this should return false
                if (value) isGrounded.TimeOfLastGrounded = time;
                isGrounded.Value = value;
            }
        }
    }
}