using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class IsFarmerAuthoring : MonoBehaviour
    {
        public class Baker : Baker<IsFarmerAuthoring>
        {
            public override void Bake(IsFarmerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent<IsFarmer>(entity);
            }
        }
    }
}