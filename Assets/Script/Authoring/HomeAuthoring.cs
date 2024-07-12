using Script.Component;
using Unity.Entities;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Authoring
{
    public class HomeAuthoring : MonoBehaviour
    {
        public Entity home;
        
        public class Baker : Baker<HomeAuthoring>
        {
            public override void Bake(HomeAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent(entity, new Home
                {
                    home = authoring.home
                });
            }
            
        }
    }
}