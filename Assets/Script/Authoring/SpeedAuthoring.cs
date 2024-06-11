using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class SpeedAuthoring : MonoBehaviour
    {
        public float speed;
        
        public class Baker : Baker<SpeedAuthoring>
        {
            public override void Bake(SpeedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent(entity, new Speed
                {
                    speed = authoring.speed
                });
            }
        }
    }
}