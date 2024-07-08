using Script.Component;
using Script.Game;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

namespace Script.System
{
    public partial struct SpawnBatSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<WantToSpawn>();
        }
        
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
                if (spawnSingleton.unit == 5)
                {
                    var ent = ecb.Instantiate(spawnerComponent.ValueRO.GoldPrefab);
                    var pos = spawnSingleton.position;
                    pos.y = 1;
                    ecb.SetComponent(ent, new LocalTransform
                    {
                        Position = pos,
                        Rotation = quaternion.identity,
                        Scale = 1f
                    });
                    GameStat.hasSpawnBat = true;
                    GameStat.countSpawn += 1;
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