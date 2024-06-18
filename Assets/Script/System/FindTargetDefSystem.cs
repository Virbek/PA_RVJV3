using System.Collections;
using System.Collections.Generic;
using Script.Component;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

partial struct FindTargetDefSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Allocator.Temp);

        foreach(var (localTransform, entity) 
                in SystemAPI.Query<RefRW<LocalTransform>>()
                    .WithAll<IsUnit>()
                    .WithAll<IsGeant>()
                    .WithNone<Target>()
                    .WithNone<OnAttack>()
                    .WithEntityAccess()
               )
        {
            var minDistance = float.MaxValue;
            Entity? targetEntity = null ;
            foreach(var(batTransform, batEntity) in SystemAPI.Query<RefRW<LocalTransform>>()
                        .WithAll<IsBat>()
                        .WithAll<IsDefense>()
                        .WithEntityAccess()
                   )
            {
                var distance = math.distance(localTransform.ValueRO.Position, batTransform.ValueRO.Position);
                if(distance <= minDistance){
                    minDistance = distance;
                    targetEntity = batEntity;
                }
            }

            ecb.AddComponent(entity, new Move());
            if (targetEntity != null)
                ecb.AddComponent(entity, new Target
                {
                    target = targetEntity.Value
                });
        }
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}
