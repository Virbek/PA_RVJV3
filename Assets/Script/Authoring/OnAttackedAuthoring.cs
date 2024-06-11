using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class OnAttackedAuthoring : MonoBehaviour
    {
        private class baker : Baker<OnAttackedAuthoring>
        {
            public override void Bake(OnAttackedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent<OnAttacked>(entity);
            }
        }
    }
}
