﻿using Script.Component;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Script.System
{
    public partial struct SpawnEntitySystem : ISystem
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

            SystemAPI.SetSingleton(new WantToSpawn
            {
                wantToSpawn = false
            });

            var ecb = new EntityCommandBuffer(Allocator.Temp);

            foreach (var (spawnerLocalTransform, 
                         spawnerComponent)
                     in SystemAPI.Query<RefRO<LocalTransform>,
                         RefRO<Spawner>>()
                    )
            {
                if (spawnSingleton.unit == 0)
                {
                    var ent = ecb.Instantiate(spawnerComponent.ValueRO.WarPrefab);
                    ecb.SetComponent(ent, new LocalTransform
                    {
                        Position = spawnSingleton.position,
                        Rotation = quaternion.identity,
                        Scale = 1f
                    });
                }
                else if (spawnSingleton.unit == 1 )
                {
                    var ent = ecb.Instantiate(spawnerComponent.ValueRO.ArrPrefab);
                    ecb.SetComponent(ent, new LocalTransform
                    {
                        Position = spawnSingleton.position,
                        Rotation = quaternion.identity,
                        Scale = 1f
                    });
                }
                else if (spawnSingleton.unit == 2 )
                {
                    var ent = ecb.Instantiate(spawnerComponent.ValueRO.GeaPrefab);
                    ecb.SetComponent(ent, new LocalTransform
                    {
                        Position = spawnSingleton.position,
                        Rotation = quaternion.identity,
                        Scale = 1f
                    });
                }
                if (spawnSingleton.unit == 5)
                {
                    var ent = ecb.Instantiate(spawnerComponent.ValueRO.GoldPrefab);
                    ecb.SetComponent(ent, new LocalTransform
                    {
                        Position = spawnSingleton.position,
                        Rotation = quaternion.identity,
                        Scale = 1f
                    });
                }
            }

            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}