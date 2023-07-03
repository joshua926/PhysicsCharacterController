using Unity.Entities;
using Unity.Mathematics;

namespace Stubblefield.PhysicsCharacterController
{
    public struct Gravity : IComponentData
    {
        /// <summary>
        /// The direction of gravity. Must be normalized.
        /// </summary>
        public float3 direction;

        /// <summary>
        /// The magnitude of gravity.
        /// </summary>
        public float magnitude;

        /// <summary>
        /// The acceleration of gravity.
        /// </summary>
        public float3 Value
        {
            get => direction * magnitude;
            set
            {
                if (Math.IsSafe(value))
                {
                    magnitude = math.length(value);
                    direction = value / magnitude;
                }
                else
                {
                    magnitude = 0;
                    direction = default;
                }
            }
        }
    }
}
