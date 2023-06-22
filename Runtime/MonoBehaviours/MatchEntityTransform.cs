using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Stubblefield.PhysicsCharacterController
{
    public class MatchEntityTransform : MonoBehaviour
    {
        public Entity entity;
        EntityManager manager;

        void Start()
        {
            manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        void LateUpdate()
        {
            LocalToWorld localToWorld = manager.GetComponentData<LocalToWorld>(entity);
            transform.position = localToWorld.Position;
            transform.rotation = localToWorld.Rotation;
            transform.localScale = localToWorld.LossyScale();
        }
    }
}
