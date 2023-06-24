using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Entities.Hybrid;

namespace Stubblefield.PhysicsCharacterController
{
    public class PhysicsCharacterControllerPlayer : MonoBehaviour
    {
        [Tooltip("The Camera in the standard Unity scene which will follow this player.")]
        public Camera cam;

        [Tooltip("This GameObject's child which will be assigned to the managed " +
            "camera's EntityTransformConstraint.target field.")]
        public GameObject cameraChildAuthoring;

        [Tooltip("How high from the ground the character's eyes are.")]
        public float cameraHeight = 1.75f;

        private void OnValidate()
        {
            if (cameraChildAuthoring && !cameraChildAuthoring.transform.IsChildOf(transform))
            {
                cameraChildAuthoring = null;
                Debug.LogWarning($"{nameof(cameraChildAuthoring)} must be a child of this GameObject.", this);
            }
        }
    }

    public class PhysicsCharacterControllerPlayerBaker : Baker<PhysicsCharacterControllerPlayer>
    {
        public override void Bake(PhysicsCharacterControllerPlayer authoring)
        {
            DependsOn(authoring.cam);

            if (!authoring.cam)
            {
                return;
            }

            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            Entity eyes = CreateAdditionalEntity(TransformUsageFlags.Dynamic);
            // todo add eyes as child to entity and set eyes height
        }
    }
}
