using Script.Component;
using Script.Game;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

namespace Script.System
{
    [UpdateBefore(typeof(DestroyEntitySystem))][BurstCompile]
    public partial struct SpawnLevelSystem : ISystem
    {
        
        public void OnCreate(ref SystemState state)
        {
            
            state.RequireForUpdate<WantToSpawn>();
        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var spawnSingleton = SystemAPI.GetSingleton<WantToSpawn>();

            if (!spawnSingleton.wantToSpawn)
            {
                return;
            }

            var ecb = new EntityCommandBuffer(Allocator.Temp);

            foreach (var (spawnerLocalTransform, 
                         spawnerComponent)
                     in SystemAPI.Query<RefRO<LocalTransform>,
                         RefRO<Spawner>>()
                    )
            {
                if (spawnSingleton.unit == 7)
                {
                    var ent = ecb.Instantiate(spawnerComponent.ValueRO.Level1Prefab);
                    var pos = spawnSingleton.position;
                    ecb.SetComponent(ent, new LocalTransform
                    {
                        Position = pos,
                        Rotation = quaternion.identity,
                        Scale = 1f
                    });
                    SystemAPI.SetSingleton(new WantToSpawn
                    {
                        wantToSpawn = false
                    });
                }
                if (spawnSingleton.unit == 8)
                {
                    var ent = ecb.Instantiate(spawnerComponent.ValueRO.Level2Prefab);
                    var pos = spawnSingleton.position;
                    ecb.SetComponent(ent, new LocalTransform
                    {
                        Position = pos,
                        Rotation = quaternion.identity,
                        Scale = 1f
                    });
                    SystemAPI.SetSingleton(new WantToSpawn
                    {
                        wantToSpawn = false
                    });
                }
                if (spawnSingleton.unit == 9)
                {
                    var ent = ecb.Instantiate(spawnerComponent.ValueRO.Level3Prefab);
                    var pos = spawnSingleton.position;
                    ecb.SetComponent(ent, new LocalTransform
                    {
                        Position = pos,
                        Rotation = quaternion.identity,
                        Scale = 1f
                    });
                    SystemAPI.SetSingleton(new WantToSpawn
                    {
                        wantToSpawn = false
                    });
                }
                if (spawnSingleton.unit == 10)
                {
                    var ent = ecb.Instantiate(spawnerComponent.ValueRO.Level4Prefab);
                    var pos = spawnSingleton.position;
                    ecb.SetComponent(ent, new LocalTransform
                    {
                        Position = pos,
                        Rotation = quaternion.identity,
                        Scale = 1f
                    });
                    SystemAPI.SetSingleton(new WantToSpawn
                    {
                        wantToSpawn = false
                    });
                }
            }
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
            
        }
    }
}