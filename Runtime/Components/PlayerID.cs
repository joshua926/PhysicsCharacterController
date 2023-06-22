using Unity.Entities;

namespace Stubblefield.PhysicsCharacterController
{
    /// <summary>
    /// Use this to differentiate between local players.
    /// </summary>
    public struct PlayerID : IComponentData
    {       
        public int value;
    }
}
