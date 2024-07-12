using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class DestroyMeAuthoring : MonoBehaviour
        {
            public class Baker : Baker<DestroyMeAuthoring>
            {
                public override void Bake(DestroyMeAuthoring authoring)
                {
                    var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                    AddComponent<DestroyMe>(entity);
                }
            }
        }
    }