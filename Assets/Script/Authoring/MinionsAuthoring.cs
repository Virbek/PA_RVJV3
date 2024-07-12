using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class MinionsAuthoring : MonoBehaviour
    {
        public GameObject minionsprefab;
        public bool spawn;
        
        public class Baker : Baker<MinionsAuthoring>
        {
            public override void Bake(MinionsAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                var minionsEntity = GetEntity(authoring.minionsprefab, TransformUsageFlags.Dynamic);
               

                AddComponent(entity, new Minions()
                {
                    minionsPrefab = minionsEntity,
                    spawn = false
                    
                });
            }
        }
    }
}
