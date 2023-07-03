using Unity.Entities;
using Unity.Mathematics;

namespace Stubblefield.PhysicsCharacterController
{
    public struct LookInput : IComponentData
    {
        /// <summary>
        /// The input value in range [0, 1].
        /// </summary>
        public float2 value;

        /// <summary>
        /// The time of the last input.
        /// </summary>
        public double time;
    }
}
