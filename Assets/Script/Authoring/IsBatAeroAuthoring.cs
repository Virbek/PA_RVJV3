using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class IsBatAeroAuthoring : MonoBehaviour
    {
        public class Baker : Baker<IsBatAeroAuthoring>
        {
            public override void Bake(IsBatAeroAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent<IsBatAero>(entity);
            }
        }
    }
}