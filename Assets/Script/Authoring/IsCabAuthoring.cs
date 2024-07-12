using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class IsCabAuthoring : MonoBehaviour
    {
        public class Baker : Baker<IsCabAuthoring>
        {
            public override void Bake(IsCabAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent<IsCab>(entity);
            }
        }
    }
}