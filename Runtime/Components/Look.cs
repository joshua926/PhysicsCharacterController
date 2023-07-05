using Unity.Entities;
using Unity.Mathematics;

namespace Stubblefield.PhysicsCharacterController
{
    public struct Look : IComponentData
    {
        /// <summary>
        /// The speed at which the orientation should change. 
        /// Positive x values look down. Positive y values look right.
        /// </summary>
        public float2 speed;
    }
}
