using Script.Component;
using UnityEngine;
using Unity.Entities;
namespace Script.Authoring
{
    public class IsProjAuthoring : MonoBehaviour
    {
        public class Baker : Baker<IsProjAuthoring>
        {
            public override void Bake(IsProjAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent<IsProj>(entity);
            }
        }
    }
}