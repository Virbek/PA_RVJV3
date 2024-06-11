using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class IsFlyingAuthoring : MonoBehaviour
    {
        public class Baker : Baker<IsFlyingAuthoring>
        {
            public override void Bake(IsFlyingAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent<IsFlying>(entity);
            }
        }
    }
}