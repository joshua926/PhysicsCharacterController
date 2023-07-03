//using Unity.Burst;
//using Unity.Collections;
//using Unity.Entities;
//using Unity.Mathematics;
//using Unity.Physics;
//using Unity.Physics.Extensions;
//using Unity.Transforms;

//namespace Stubblefield.PhysicsCharacterController
//{
//    [BurstCompile]
//    public partial struct Runner : ISystem
//    {
//        [BurstCompile]
//        public void OnUpdate(ref SystemState state)
//        {
//            new Job().ScheduleParallel();
//        }

//        [BurstCompile]
//        partial struct Job : IJobEntity
//        {
//            [ReadOnly] public CollisionWorld collisionWorld;            

//            [BurstCompile]
//            public void Execute(
//                ref PhysicsVelocity physicsVelocity,
//                in RunParams run,
//                in LocalToWorld transform,
//                in PhysicsMass mass)
//            {
//                float3 start = transform.Position;
//                RaycastInput input = new()
//                {
//                    Start = start,
//                    End = start + check.gravityDirection * check.checkDistance,
//                    Filter = Phys.DefaultCollisionFilter,
//                };
//                if (!collisionWorld.CastRay(input, out RaycastHit hit))
//                {
//                    check.isGrounded = false;
//                    return;
//                }


//                if (!isGrounded) return;
//                //if (run.localMoveVector.Equals(0)) return;
//                Maths.GetSurfaceForwardAndRight(isGrounded.groundNormal, out float3 groundRight, out float3 groundForward);
//                float2 worldInput = Maths.LocalToWorld2d(look.Forward2d, run.localMoveVector);
//                float2 localVelocity2dTarget = worldInput * run.maxSpeed;
//                float3 localVelocity3dCurrent = physicsVelocity.Linear - isGrounded.groundVelocity;
//                float2 localVelocity2dCurrent = Maths.Vector3dToVector2dOnPlane(localVelocity3dCurrent, groundRight, groundForward);
//                float2 localAcceleration2d = localVelocity2dTarget - localVelocity2dCurrent;
//                float3 localAcceleration3d = Maths.Vector2dOnPlaneToVector3d(localAcceleration2d, groundRight, groundForward);
//                float3 force = mass.Mass() * localAcceleration3d;
//                float3 clampedForce = Maths.ClampVectorLength(force, 0, run.maxForce);
//                physicsVelocity.ApplyLinearImpulse(mass, clampedForce);
//            }
//        }
//    }
//}