using Unity.Entities;
using Unity.Mathematics;

namespace Stubblefield.PhysicsCharacterController
{
    public struct Jump : IComponentData, IEnableableComponent
    {        
        float force;

        /// <summary>
        /// The force with which the subject jumps. Must be positive.
        /// </summary>
        public float Force
        {
            get => force;
            set => force = math.abs(value) * math.sign(force);
        }

        /// <summary>
        /// Is the subject currently requesting to jump?
        /// </summary>
        public bool JumpRequested
        {
            get => force > 0;
            set => force = math.abs(force) * (value ? 1 : -1);
        }
    }
}
