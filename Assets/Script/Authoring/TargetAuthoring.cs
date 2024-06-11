using Script.Component;
using Unity.Entities;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Authoring
{
    public class TargetAuthoring : MonoBehaviour
    {
        public Entity target;
        
        public class Baker : Baker<TargetAuthoring>
        {
            public override void Bake(TargetAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent(entity, new Target
                {
                    target = authoring.target
                });
            }
            
        }
    }
}