using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class IsSelectedAuthoring : MonoBehaviour
    {
        public class Baker : Baker<IsSelectedAuthoring>
        {
            public override void Bake(IsSelectedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent(entity, new IsSelected()
                {
                });
            }
        }
    }
}