using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class IsGeantAuthoring : MonoBehaviour
    {
        public class Baker : Baker<IsGeantAuthoring>
        {
            public override void Bake(IsGeantAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent<IsGeant>(entity);
            }
        }
    }
}