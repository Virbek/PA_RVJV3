using Script.Component;
using Unity.Entities;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Authoring
{
    public class ProjectilesAuthoring : MonoBehaviour
    {
        public GameObject prefab;
        public class Baker : Baker<ProjectilesAuthoring>
        {
            public override void Bake(ProjectilesAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                var ArrowEntity = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic);
                AddComponent(entity, new Projectiles()
                {
                    prefab = ArrowEntity
                });
            }
        }
    }
}