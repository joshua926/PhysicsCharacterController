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

        /// <summary>
        /// The allowed range of angles in radians. Must be in range [-90 degrees, 90 degrees].
        /// The first component is expected to be the min and the second component 
        /// is expected to be the max.
        /// </summary>
        public float2 allowedAngleRange;
    }
}