using Script.Component;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.System
{
    [BurstCompile]
    partial struct FindTargetForBatSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            foreach (var (localTransform, range, entity)
                     in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RangeAttack>>()
                         .WithAll<IsBat>()
                         .WithNone<IsBatAero>()
                         .WithAll<IsDefense>()
                         .WithNone<Target>()
                         .WithEntityAccess()
                    )
            {
                foreach (var (unitTransform, unitEntity)
                         in SystemAPI.Query<RefRW<LocalTransform>>()
                             .WithAll<IsUnit>()
                             .WithNone<IsFlying>()
                             .WithEntityAccess()
                        )
                {
                    var distance = Vector3.Distance(localTransform.ValueRO.Position, unitTransform.ValueRO.Position);
                    if (distance <= range.ValueRO.rangeAttack)
                    {
                        ecb.AddComponent<OnAttack>(entity);
                        ecb.AddComponent(entity, new Target
                        {
                            target = unitEntity
                        });
                    }
                }
            }

            foreach (var (localTransform, range, entity)
                     in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RangeAttack>>()
                         .WithAll<IsBatAero>()
                         .WithAll<IsDefense>()
                         .WithNone<Target>()
                         .WithEntityAccess()
                    )
            {
                foreach (var (unitTransform, unitEntity)
                         in SystemAPI.Query<RefRW<LocalTransform>>()
                             .WithAll<IsUnit>()
                             .WithEntityAccess()
                        )
                {
                    var distance = Vector3.Distance(localTransform.ValueRO.Position, unitTransform.ValueRO.Position);
                    if (distance <= range.ValueRO.rangeAttack)
                    {
                        ecb.AddComponent<OnAttack>(entity);
                        ecb.AddComponent(entity, new Target
                        {
                            target = unitEntity
                        });
                    }
                }
            }
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}