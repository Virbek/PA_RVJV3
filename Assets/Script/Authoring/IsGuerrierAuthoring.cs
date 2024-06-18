using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class IsGuerrierAuthoring : MonoBehaviour
    {
        public class Baker : Baker<IsGuerrierAuthoring>
        {
            public override void Bake(IsGuerrierAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent<IsGuerrier>(entity);
            }
        }
    }
}