using Unity.Entities;
using Unity.Mathematics;

namespace Stubblefield.PhysicsCharacterController
{
    /// <summary>
    /// This component allows you to know an entity's current acceleration.
    /// Setting this value has no effect on the physics system. 
    /// </summary>
    public struct Acceleration : IComponentData, IEnableableComponent
    {
        /// <summary>
        /// The velocity from the last time this component was updated.
        /// </summary>
        public float3 priorVelocity;

        /// <summary>
        /// The current acceleration.
        /// </summary>
        public float3 value;
    }
}
