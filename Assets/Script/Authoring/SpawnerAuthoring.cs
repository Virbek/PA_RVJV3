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
        public GameObject DestroyPrefab;
        public GameObject Level1Prefab;
        public GameObject Level2Prefab;
        public GameObject Level3Prefab;
        public GameObject Level4Prefab;
        public GameObject TreePrefab;
        public GameObject CabanePrefab;
        
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
                var destroyEntity = GetEntity(authoring.DestroyPrefab, TransformUsageFlags.Dynamic);
                var level1Entity = GetEntity(authoring.Level1Prefab, TransformUsageFlags.Dynamic);
                var level2Entity = GetEntity(authoring.Level2Prefab, TransformUsageFlags.Dynamic);
                var level3Entity = GetEntity(authoring.Level3Prefab, TransformUsageFlags.Dynamic);
                var level4Entity = GetEntity(authoring.Level4Prefab, TransformUsageFlags.Dynamic);
                var treeEntity = GetEntity(authoring.TreePrefab, TransformUsageFlags.Dynamic);
                var cabaneEntity = GetEntity(authoring.CabanePrefab, TransformUsageFlags.Dynamic);

                AddComponent(entity, new Spawner
                {
                    WarPrefab = warEntity,
                    ArrPrefab = arrEntity,
                    GeaPrefab = geaEntity,
                    BallPrefab = ballEntity,
                    BallDefPrefab = ballDefEntity,
                    GoldPrefab = goldEntity,
                    DestroyPrefab = destroyEntity,
                    Level1Prefab = level1Entity,
                    Level2Prefab = level2Entity,
                    Level3Prefab = level3Entity,
                    Level4Prefab = level4Entity,
                    TreePrefab = treeEntity,
                    CabanePrefab = cabaneEntity
                    
                });
            }
        }
    }
}
