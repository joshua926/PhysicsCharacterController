using Unity.Entities;

namespace Stubblefield.PhysicsCharacterController
{
    public struct JumpInput : IComponentData
    {
        /// <summary>
        /// The time of the last input.
        /// </summary>
        public double time;

        /// <summary>
        /// The duration of time before being grounded that a jump request 
        /// will be honored. Once the subject becomes grounded, the jump will
        /// be performed.
        /// </summary>
        public float preGroundedGraceDuration;

        /// <summary>
        /// The duration of time after being grounded that a jump request 
        /// will still be honored.
        /// </summary>
        public float postGroundedGraceDuration;

        /// <summary>
        /// The duration of time after performing a jump in which another jump cannot be performed.
        /// </summary>
        public float postJumpWaitDuration;
    }
}
