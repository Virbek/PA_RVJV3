using System.Security.Cryptography;
using Script.Component;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Script.System
{
    partial struct DestroyEntitySystem : ISystem
    {
        
        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            var destroyEntity = Entity.Null;
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
            foreach (var (geantHealth,entity) in SystemAPI.Query<RefRO<NombrePv>>()
                         .WithAll<IsUnit>()
                         .WithAll<IsGeant>()
                         .WithEntityAccess())
            {
                if (geantHealth.ValueRO.pv <= 0)
                {
                    ecb.RemoveComponent<IsUnit>(entity);
                    ecb.AddComponent<Disabled>(entity);
                    NumberUnit.geant -= 1;
                }
            }

            foreach (var (arrowTransform, entity)
                     in SystemAPI.Query<RefRO<LocalTransform>>()
                         .WithAll<IsProj>()
                         .WithNone<Target>()
                         .WithEntityAccess()
                    )
            {
                ecb.RemoveComponent<IsProj>(entity);
                ecb.AddComponent<Disabled>(entity);
            }
            
            foreach (var (localTransform, entity) in SystemAPI.Query<RefRO<LocalTransform>>()
                         .WithAll<DestroyOther>()
                         .WithEntityAccess())
            {
                foreach (var (unitTransform,unitEntity) in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<IsUnit>().WithEntityAccess())
                {
                    ecb.RemoveComponent<IsUnit>(unitEntity);
                    ecb.AddComponent<Disabled>(unitEntity);
                }
                foreach (var (projTransform,projEntity) in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<IsProj>().WithEntityAccess())
                {
                    ecb.RemoveComponent<IsProj>(projEntity);
                    ecb.AddComponent<Disabled>(projEntity);
                }

                foreach (var (batTransform, batEntity) in SystemAPI.Query<RefRO<LocalTransform>>()
                             .WithAll<IsBat>()
                             .WithEntityAccess()
                        )
                {
                    ecb.RemoveComponent<IsBat>(batEntity);
                    ecb.AddComponent<Disabled>(batEntity);
                }
                foreach (var (collTransform, collEntity) in SystemAPI.Query<RefRO<LocalTransform>>()
                             .WithAll<IsRessourceGold>()
                             .WithEntityAccess()
                        )
                {
                    ecb.RemoveComponent<IsRessourceGold>(collEntity);
                    ecb.AddComponent<Disabled>(collEntity);
                }
                foreach (var (cabTransform, cabEntity) in SystemAPI.Query<RefRO<LocalTransform>>()
                             .WithAll<IsCab>()
                             .WithEntityAccess()
                        )
                {
                    ecb.RemoveComponent<IsCab>(cabEntity);
                    ecb.AddComponent<Disabled>(cabEntity);
                }

                destroyEntity = entity;
            }

            if (destroyEntity != Entity.Null)
            {
                ecb.RemoveComponent<DestroyOther>(destroyEntity);
                ecb.AddComponent<Disabled>(destroyEntity);
            }
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}
