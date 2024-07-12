using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class LevelAuthoring : MonoBehaviour
        {
            public class Baker : Baker<LevelAuthoring>
            {
                public override void Bake(LevelAuthoring authoring)
                {
                    var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                    AddComponent<Level>(entity);
                }
            }
        }
    }