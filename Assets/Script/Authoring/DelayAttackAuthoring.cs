using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class DelayAttackAuthoring : MonoBehaviour
    {
        public float delayAttack;
        public class Baker : Baker<DelayAttackAuthoring>
        {
            public override void Bake(DelayAttackAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent(entity, new DelayAttack
                {
                    delayAttack = authoring.delayAttack
                });
            }
        }
    }
}