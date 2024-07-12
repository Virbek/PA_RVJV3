using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class DestroyOtherAuthoring : MonoBehaviour
        {
            public class Baker : Baker<DestroyOtherAuthoring>
            {
                public override void Bake(DestroyOtherAuthoring authoring)
                {
                    var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                    AddComponent<DestroyOther>(entity);
                }
            }
        }
    }