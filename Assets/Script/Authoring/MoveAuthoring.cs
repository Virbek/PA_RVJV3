using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class MoveAuthoring : MonoBehaviour
    {
        public class Baker : Baker<MoveAuthoring>
        {
            public override void Bake(MoveAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent(entity, new IsSelected()
                {
                });
            }
        }
    }
}