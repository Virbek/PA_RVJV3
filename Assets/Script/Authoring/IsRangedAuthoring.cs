using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class IsRangedAuthoring : MonoBehaviour
    {
        public class Baker : Baker<IsRangedAuthoring>
        {
            public override void Bake(IsRangedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent<IsRanged>(entity);
            }
        }
    }
}