using Script.Component;
using Unity.Entities;
using UnityEngine;


namespace Script.Authoring
{
    public class CollectableAuthoring : MonoBehaviour
    {
        public float timeToCollect;
        public class Baker : Baker<CollectableAuthoring>
        {
            public override void Bake(CollectableAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new Collectable
                {
                    timeToCollect = authoring.timeToCollect
                });
            }
        }
    }
}