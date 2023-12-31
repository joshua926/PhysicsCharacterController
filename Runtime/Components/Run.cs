using Unity.Entities;
using Unity.Mathematics;

namespace Stubblefield.PhysicsCharacterController
{
    public struct Run : IComponentData
    {
        /// <summary> 
        /// The desired movement vector in the character's local space.
        /// Each component must be in the range [0,1].
        /// </summary>
        public float2 value;

        /// <summary>
        /// The last time this was applied.
        /// </summary>
        public double time;
    }
}
