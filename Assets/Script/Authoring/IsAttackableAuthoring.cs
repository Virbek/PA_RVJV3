using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class IsAttackableAuthoring : MonoBehaviour
    {
        public class Baker : Baker<IsAttackableAuthoring>
        {
            public override void Bake(IsAttackableAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent<IsAttackable>(entity);
            }
        }
    }
}
