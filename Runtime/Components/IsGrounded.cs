using Unity.Entities;
using Unity.Mathematics;

namespace Stubblefield.PhysicsCharacterController
{  
    public struct IsGrounded : IComponentData
    {
        double time;

        /// <summary>
        /// The time at which the subject was last grounded.
        /// </summary>
        public double TimeOfLastGrounded
        {
            get => math.abs(time);
            set
            {
                double sign = math.sign(time);
                time = math.abs(value) * sign;
            }
        }

        public bool Value
        {
            get => time > 0;
            set => time = math.abs(time) * (value ? 1 : -1);           
        }
    }
}