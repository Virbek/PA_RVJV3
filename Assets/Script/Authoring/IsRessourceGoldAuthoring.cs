using Script.Component;
using Unity.Entities;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Authoring
{
    public class IsRessourceGoldAuthoring : MonoBehaviour
    {
        public class Baker : Baker<IsRessourceGoldAuthoring>
        {
            public override void Bake(IsRessourceGoldAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent<IsRessourceGold>(entity);
            }
        }
    }
}
