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
    public partial struct SpawnFarmerSystem : ISystem
    {
        
        public void OnUpdate(ref SystemState state)
        {

            var ecb = new EntityCommandBuffer(Allocator.Temp);

            foreach (var (localTransform,minions ,entity)
                     in SystemAPI.Query<RefRO<LocalTransform>, RefRW<Minions>>()
                         .WithAll<IsCab>()
                         .WithEntityAccess()
                    )
            {
                if (!minions.ValueRO.spawn)
                {
                    var ent = ecb.Instantiate(minions.ValueRO.minionsPrefab);
                    ecb.SetComponent(ent, new LocalTransform
                    {
                        Position = localTransform.ValueRO.Position,
                        Rotation = quaternion.identity,
                        Scale = 1f
                    });
                    minions.ValueRW.spawn = true;
                    ecb.SetComponent(ent, new Home
                    {
                        home = entity
                    });
                }
            }
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
            
        }
    }
}