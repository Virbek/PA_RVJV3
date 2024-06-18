using Script.Component;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Script.System
{
    partial struct DestroyEntitySystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            foreach(var (health, entity) in SystemAPI.Query<RefRO<NombrePv>>()
                        .WithAll<IsBat>()
                        .WithEntityAccess()
                   )
            {
                if(health.ValueRO.pv <= 0)
                {
                    ecb.RemoveComponent<IsBat>(entity);
                    ecb.AddComponent<Disabled>(entity);
                    NumberUnit.bat -= 1;

                }
            }

            foreach (var (guerrierHealth,entity) in SystemAPI.Query<RefRO<NombrePv>>()
                         .WithAll<IsUnit>()
                         .WithAll<IsGuerrier>()
                         .WithEntityAccess())
            {
                if (guerrierHealth.ValueRO.pv <= 0)
                {
                    ecb.RemoveComponent<IsUnit>(entity);
                    ecb.AddComponent<Disabled>(entity);
                    NumberUnit.guerrier -= 1;
                }
            }
            foreach (var (archerHealth,entity) in SystemAPI.Query<RefRO<NombrePv>>()
                         .WithAll<IsUnit>()
                         .WithAll<IsArcher>()
                         .WithEntityAccess())
            {
                if (archerHealth.ValueRO.pv <= 0)
                {
                    ecb.RemoveComponent<IsUnit>(entity);
                    ecb.AddComponent<Disabled>(entity);
                    NumberUnit.archer -= 1;
                }
            }
            foreach (var (archerHealth,entity) in SystemAPI.Query<RefRO<NombrePv>>()
                         .WithAll<IsUnit>()
                         .WithAll<IsGeant>()
                         .WithEntityAccess())
            {
                if (archerHealth.ValueRO.pv <= 0)
                {
                    ecb.RemoveComponent<IsUnit>(entity);
                    ecb.AddComponent<Disabled>(entity);
                    NumberUnit.geant -= 1;
                }
            }
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}
