using Unity.Entities;
using Unity.Mathematics;

namespace Stubblefield.PhysicsCharacterController
{
    public struct RunInput : IComponentData
    {
        /// <summary>
        /// The input value in range [0, 1].
        /// </summary>
        public float2 value;

        /// <summary>
        /// The time of last input.
        /// </summary>
        public double time;

        /// <summary>
        /// The duration of time before being grounded that the subject
        /// can begin exerting run forces.
        /// </summary>
        public float preGroundedGraceDuration;

        /// <summary>
        /// The duration of time after being grounded that the subject 
        /// can still exert run forces.
        /// </summary>
        public float postGroundedGraceDuration;
    }
}
