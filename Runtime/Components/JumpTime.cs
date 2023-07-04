using Unity.Entities;

namespace Stubblefield.PhysicsCharacterController
{
    public struct JumpTime : IComponentData
    {
        /// <summary>
        /// The last time this entity started a jump.
        /// </summary>
        public double startTime;
    }
}
