using Unity.Entities;
using Unity.Mathematics;

namespace Stubblefield.PhysicsCharacterController
{
    public struct JumpStats : IComponentData, IEnableableComponent
    {      
        /// <summary>
        /// The jump force.
        /// </summary>
        public float force;
    }
}
