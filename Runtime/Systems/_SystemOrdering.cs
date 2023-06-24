using Unity.Entities;
using Unity.Physics.Systems;

namespace Stubblefield.PhysicsCharacterController
{
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateBefore(typeof(PhysicsSystemGroup))]
    [UpdateAfter(typeof(JumpRequester))]
    [UpdateAfter(typeof(PlayerInputSetter))]
    public partial struct Jumper { }

    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateBefore(typeof(PhysicsSystemGroup))]
    public partial struct AccelerationSetter { }

    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateBefore(typeof(PhysicsSystemGroup))]
    [UpdateAfter(typeof(AccelerationSetter))]
    public partial struct IsGroundedSetter { }

    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateBefore(typeof(PhysicsSystemGroup))]
    [UpdateAfter(typeof(IsGroundedSetter))]
    [UpdateAfter(typeof(PlayerInputSetter))]
    public partial struct JumpRequester { }

    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateBefore(typeof(Runner))]
    [UpdateBefore(typeof(Looker))]
    [UpdateBefore(typeof(Jumper))]
    public partial class PlayerInputSetter { }


}
