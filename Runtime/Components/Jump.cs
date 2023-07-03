using Unity.Entities;

namespace Stubblefield.PhysicsCharacterController
{
    public struct Jump : IComponentData, IEnableableComponent
    {
        /// <summary>
        /// The time this was last applied.
        /// </summary>
        public float time;
    }
}
