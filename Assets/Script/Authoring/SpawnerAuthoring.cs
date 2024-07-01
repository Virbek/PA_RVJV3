using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class SpawnerAuthoring : MonoBehaviour
    {
        public GameObject warprefab;
        public GameObject arrprefab;
        public GameObject geaprefab;
        public GameObject ballprefab;
        public GameObject ballDefprefab;
        public GameObject GoldPrefab;

        public class Baker : Baker<SpawnerAuthoring>
        {
            public override void Bake(SpawnerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                var warEntity = GetEntity(authoring.warprefab, TransformUsageFlags.Dynamic);
                var arrEntity = GetEntity(authoring.arrprefab, TransformUsageFlags.Dynamic);
                var geaEntity = GetEntity(authoring.geaprefab, TransformUsageFlags.Dynamic);
                var ballEntity = GetEntity(authoring.ballprefab, TransformUsageFlags.Dynamic);
                var ballDefEntity = GetEntity(authoring.ballDefprefab, TransformUsageFlags.Dynamic);
                var goldEntity = GetEntity(authoring.GoldPrefab, TransformUsageFlags.Dynamic);

                AddComponent(entity, new Spawner
                {
                    WarPrefab = warEntity,
                    ArrPrefab = arrEntity,
                    GeaPrefab = geaEntity,
                    BallPrefab = ballEntity,
                    BallDefPrefab = ballDefEntity,
                    GoldPrefab = goldEntity
                    
                });
            }
        }
    }
}
