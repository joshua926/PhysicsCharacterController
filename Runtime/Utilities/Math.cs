using Unity.Mathematics;
using Unity.Transforms;

namespace Stubblefield.PhysicsCharacterController
{
    public static class Math
    {
        /// <summary>
        /// Multiply radians by this to get degrees.
        /// </summary>
        public const float radiansPerDegree = (math.PI * 2) / 360;

        /// <summary>
        /// Multiply degrees by this to get radians.
        /// </summary>
        public const float degreesPerRadian = 360 / (math.PI * 2);

        /// <summary>
        /// In radians.
        /// </summary>
        public const float rightAngle = math.PI * .5f;

        /// <summary>
        /// Converts an angle in radians to a unit length vector. 
        /// Angles start on positive x-axis and rotate counter clockwise as they get more positive.
        /// For example, angle 0 returns (1, 0). Angle PI/2 (90 degrees) would return (0, 1).
        /// </summary>
        public static float2 AngleToVector(float angle)
        {
            return new float2(math.cos(angle), math.sin(angle));
        }

        /// <summary>
        /// The vector pointing right given this orientation.
        /// </summary>
        public static float3 Right(this quaternion value)
        {
            return math.mul(value, math.right());
        }

        /// <summary>
        /// The vector pointing up given this orientation.
        /// </summary>
        public static float3 Up(this quaternion value)
        {
            return math.mul(value, math.up());
        }

        /// <summary>
        /// The vector pointing forward given this orientation.
        /// </summary>
        public static float3 Forward(this quaternion value)
        {
            return math.mul(value, math.forward());
        }

        /// <summary>
        /// Create an orientation given a right and up vector.
        /// </summary>
        public static quaternion RotationFromRightUp(float3 right, float3 up)
        {
            float3 forward = math.cross(right, up);
            return quaternion.LookRotationSafe(forward, up);
        }

        /// <summary>
        /// Create an orientation given a right and up vector.
        /// </summary>
        public static quaternion RotationFromRightForward(float3 right, float3 forward)
        {
            float3 up = math.cross(-right, forward);
            return quaternion.LookRotationSafe(forward, up);
        }

        /// <summary>
        /// Create an orientation given a right and up vector.
        /// </summary>
        public static quaternion RotationFromUpForward(float3 up, float3 forward)
        {
            return quaternion.LookRotationSafe(forward, up);
        }

        /// <summary>
        /// Calculates scale from a LocalToWorld component. If it contains skew, 
        /// then the returned value will be inexact.
        /// </summary>
        public static float3 LossyScale(this LocalToWorld localToWorld)
        {            
            // If LocalToWorld contains skew, returned value will be inexact,
            // and diverge from GameObjects.
            float lx = math.length(localToWorld.Value.c0.xyz);
            float ly = math.length(localToWorld.Value.c1.xyz);
            float lz = math.length(localToWorld.Value.c2.xyz);
            return new float3(lx, ly, lz);            
        }

        
        /// <returns>True if all components are finite, all components are not NaN, and at least one component is non-zero.</returns>
        public static bool IsSafe(float3 value)
        {
            return math.all(math.isfinite(value)) & math.all(!math.isnan(value)) & math.any(value != 0);
        }

        /// <summary>
        /// Returns the shortest angle in radians between 2 vectors.
        /// </summary>
        public static float Angle(float2 a, float2 b)
        {
            a = math.normalize(a);
            b = math.normalize(b);
            float dot = math.dot(a, b);
            dot = math.clamp(dot, -1, 1);
            return math.acos(dot);
        }

        /// <summary>
        /// Returns the shortest angle in radians between 2 vectors.
        /// </summary>
        public static float Angle(float3 a, float3 b)
        {
            a = math.normalize(a);
            b = math.normalize(b);
            float dot = math.dot(a, b);
            dot = math.clamp(dot, -1, 1);
            return math.acos(dot);                       
        }
    }
}
