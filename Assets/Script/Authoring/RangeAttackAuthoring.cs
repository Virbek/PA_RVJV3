using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class RangeAttackAuthoring : MonoBehaviour
    {
        public float rangeAttack;
        public class Baker : Baker<RangeAttackAuthoring>
        {
            public override void Bake(RangeAttackAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent(entity, new RangeAttack
                {
                   rangeAttack = authoring.rangeAttack
                });
            }
        }
    }
}