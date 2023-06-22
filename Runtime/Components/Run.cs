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
        public float2 moveVector;

        /// <summary>
        /// The max speed the character can run at.
        /// </summary>
        public float maxSpeed;

        /// <summary>
        /// The max force the character can apply to speed up or slow down.
        /// </summary>
        public float maxForce;
    }
}
