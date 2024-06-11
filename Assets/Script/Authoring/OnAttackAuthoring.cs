using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class OnAttackAuthoring : MonoBehaviour
    {
        private class Baker : Baker<OnAttackAuthoring>
        {
            public override void Bake(OnAttackAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent<OnAttack>(entity);
            }
        }
    }
}