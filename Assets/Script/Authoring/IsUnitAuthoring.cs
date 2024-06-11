using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class IsUnitAuthoring : MonoBehaviour
    {

        public class Baker : Baker<IsUnitAuthoring>
        {
            public override void Bake(IsUnitAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new IsUnit
                {
                });
            }
        }
    }
}
