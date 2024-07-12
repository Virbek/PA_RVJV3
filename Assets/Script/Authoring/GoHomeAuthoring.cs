using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class GoHomeAuthoring : MonoBehaviour
    {

        public class Baker : Baker<GoHomeAuthoring>
        {
            public override void Bake(GoHomeAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new GoHome()
                {
                });
            }
        }
    }
}
