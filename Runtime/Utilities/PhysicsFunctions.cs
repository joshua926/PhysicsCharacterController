using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

namespace Stubblefield.PhysicsCharacterController
{
    public static class PhysicsFunctions
    {
        public static CollisionFilter DefaultCollisionFilter() => new CollisionFilter()
        {
            BelongsTo = ~0u,
            CollidesWith = ~0u, // all 1s, so all layers, collide with everything
            GroupIndex = 0
        };

        public static float Mass(this PhysicsMass mass)
        {
            return math.rcp(mass.InverseMass);
        }

        //public static SurfaceHit Raycast(
        //    in CollisionWorld collisionWorld,
        //    in ComponentLookup<PhysicsVelocity> velocityLookup,
        //    float3 start,
        //    float3 direction,
        //    float3 checkDistance,
        //    double ellapsedTime)
        //{
        //    RaycastInput input = new()
        //    {
        //        Start = start,
        //        End = start + direction * checkDistance,
        //        Filter = PhysicsFunctions.DefaultCollisionFilter()
        //    };
        //}
    }
}
