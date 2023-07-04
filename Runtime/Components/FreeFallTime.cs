using Unity.Entities;
using Unity.Mathematics;

namespace Stubblefield.PhysicsCharacterController
{
    public struct FreeFallTime : IComponentData
    {        
        /// <summary>
        /// The last time this entity started free falling.
        /// </summary>
        public double startTime;

        /// <summary>
        /// The last time this entity stopped free falling.
        /// </summary>
        public double endTime;
    }
}