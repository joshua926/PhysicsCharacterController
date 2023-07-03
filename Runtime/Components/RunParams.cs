using Unity.Entities;
using Unity.Mathematics;

namespace Stubblefield.PhysicsCharacterController
{
    public struct RunParams : IComponentData
    {        
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
