using Unity.Entities;

namespace Stubblefield.PhysicsCharacterController
{
    public struct Jump : IComponentData
    {
        /// <summary>
        /// The time of the last jump request.
        /// </summary>
        public double requestTime;

        /// <summary>
        /// The time of the last performed jump.
        /// </summary>
        public double performedTime;

        /// <summary>
        /// The force with which the subject jumps.
        /// </summary>
        public float force;

        /// <summary>
        /// The duration of time before being grounded that a jump request 
        /// will be honored. Once the subject becomes grounded, the jump will
        /// be performed.
        /// </summary>
        public float preGraceDuration;

        /// <summary>
        /// The duration of time after being grounded that a jump request 
        /// will still be honored.
        /// </summary>
        public float postGraceDuration;
    }
}
