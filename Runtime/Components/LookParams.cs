using Unity.Entities;
using Unity.Mathematics;

namespace Stubblefield.PhysicsCharacterController
{
    /// <summary>
    /// Describes a subject's look orientation.
    /// </summary>
    public struct LookParams : IComponentData
    {      
        /// <summary>
        /// The max rate of change for the look angles in radians per second.
        /// </summary>
        public float2 maxSpeed;

        // radians = degrees * PI / 180
        public const float minVerticalAngle = -90 * math.PI / 180;
        public const float maxVerticalAngle = 90 * math.PI / 180;
    }
}