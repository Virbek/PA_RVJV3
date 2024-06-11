using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class PuissanceAuthoring : MonoBehaviour
    {
        public int puissance;
        public class Baker : Baker<PuissanceAuthoring>
        {
            public override void Bake(PuissanceAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent(entity, new Puissance
                {
                    puissance = authoring.puissance
                });
            }
        }
    }
}