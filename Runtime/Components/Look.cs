using Unity.Entities;
using Unity.Mathematics;

namespace Stubblefield.PhysicsCharacterController
{
    /// <summary>
    /// Describes a subject's look orientation.
    /// </summary>
    public struct Look : IComponentData
    {
        /// <summary>
        /// The euler angles that describe the subject's current look orientation.
        /// </summary>
        public float2 angles;

        /// <summary>
        /// The rate of change for the look angles in radians per second.
        /// </summary>
        public float2 speed;

        // radians = degrees * PI / 180
        public const float minVerticalAngle = -90 * math.PI / 180;
        public const float maxVerticalAngle = 90 * math.PI / 180;

        /// <summary>
        /// Radians. The angle of rotation on the y-axis. Positive values look to the right.
        /// </summary>
        public float HorizontalAngle 
        {
            get => angles.y;
            set => angles.y = value;
        }

        /// <summary>
        /// Radians. The angle of rotation on the x-axis. Positive values look down.
        /// </summary>
        public float VerticalAngle
        {
            get => angles.x;
            set => angles.x = value;
        }

        /// <summary>
        /// Radians per second. The rate of change for the rotation on the y-axis.
        /// </summary>
        public float HorizontalSpeed
        {
            get => speed.y;
            set => speed.y = value;
        }

        /// <summary>
        /// Radians per second. The rate of change for the rotation on the x-axis.
        /// </summary>
        public float VerticalSpeed
        {
            get => speed.x;
            set => speed.x = value;
        }
    }
}