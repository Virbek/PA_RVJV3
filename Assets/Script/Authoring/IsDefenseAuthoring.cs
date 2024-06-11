using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class IsDefenseAuthoring : MonoBehaviour
    {
        
        public class Baker : Baker<IsDefenseAuthoring>
        {
            public override void Bake(IsDefenseAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent<IsDefense>(entity);
            }
        }
    }
}