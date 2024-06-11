using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class IsBatAuthoring : MonoBehaviour
    {
        public class Baker : Baker<IsBatAuthoring>
        {
            public override void Bake(IsBatAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent<IsBat>(entity);
            }
        }
    }
}