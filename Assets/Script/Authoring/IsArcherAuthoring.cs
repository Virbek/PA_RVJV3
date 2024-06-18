using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class IsArcherAuthoring : MonoBehaviour
    {
        public class Baker : Baker<IsArcherAuthoring>
        {
            public override void Bake(IsArcherAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent<IsArcher>(entity);
            }
        }
    }
}